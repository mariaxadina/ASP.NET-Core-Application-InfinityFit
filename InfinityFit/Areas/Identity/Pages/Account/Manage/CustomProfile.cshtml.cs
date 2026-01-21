using InfinityFit.Data;
using InfinityFit.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfinityFit.Areas.Identity.Pages.Account.Manage
{

    public class CustomProfileModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpClientFactory _http;
        private readonly string _geoapifyKey;
        private readonly ApplicationDbContext _db;

        public CustomProfileModel(UserManager<User> userManager, IHttpClientFactory http, IOptions<InfinityFit.Options.Geoapify> geoapifyOptions, ApplicationDbContext db)
        {
            _userManager = userManager;
            _http = http;
            _geoapifyKey = geoapifyOptions.Value.ApiKey;
            _db = db;
        }

        // The currently logged-in user
        public User CurrentUser { get; set; }

        // Bindable property for DailyDistanceGoal so the form can update it
        [BindProperty]
        public float? DailyDistanceGoal { get; set; }

        [BindProperty]
        public int? TotalPoints { get; set; } // optional if you want to show/update

        [BindProperty]
        public int? Level { get; set; }
        [BindProperty]
        public double? Latitude { get; set; }

        [BindProperty]
        public double? Longitude { get; set; }
        public string LocationOfTheDay { get; set; } = string.Empty;
        public string? TouristAddress { get; set; }
        public double? TouristLatitude { get; set; }
        public double? TouristLongitude { get; set; }



        public IList<UserBadge> UserBadges { get; set; } = new List<UserBadge>();

        public IList<Post> Posts { get; set; } = new List<Post>();

        public async Task OnGetAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            
            if (CurrentUser != null)
            {
                DailyDistanceGoal = CurrentUser.Daily_Distance_Goal;
                TotalPoints = CurrentUser.TotalPoints;
                Level = CurrentUser.Level;
            }



            var userId = CurrentUser.Id;

            UserBadges = await _db.UserBadges
                .Where(ub => ub.UserId == userId)
                .Include(ub => ub.Badge)
                .ToListAsync();

            Posts = await _db.Posts
                .Where(p => p.UserId == userId)
                .Include(l => l.Likes)
                .Include(c => c.Comments)
                .OrderBy(d => d.DateOfCreation)
                .ToListAsync();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            CurrentUser = await _userManager.GetUserAsync(User);

            if (CurrentUser == null)
            {
                return NotFound("User not found");
            }

            var userId = CurrentUser.Id;

            UserBadges = await _db.UserBadges
                .Where(ub => ub.UserId == userId)
                .Include(ub => ub.Badge)
                .ToListAsync();

            Posts = await _db.Posts
                .Where(p => p.UserId == userId)
                .Include(l => l.Likes)
                .Include(c => c.Comments)
                .OrderBy(d => d.DateOfCreation)
                .ToListAsync();

            // Update the daily distance goal
            CurrentUser.Daily_Distance_Goal = DailyDistanceGoal;

            // Optionally update other fields here (TotalPoints, Level etc.)

            var result = await _userManager.UpdateAsync(CurrentUser);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            TempData["StatusMessage"] = "Profile updated successfully!";
            return RedirectToPage(); // Reload the page
        }
        public static double GetDistanceKm(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; // raz? P?m�nt �n km
            var dLat = (lat2 - lat1) * Math.PI / 180.0;
            var dLon = (lon2 - lon1) * Math.PI / 180.0;
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(lat1 * Math.PI / 180.0) * Math.Cos(lat2 * Math.PI / 180.0) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }
        public async Task<IActionResult> OnPostGetLocationAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            if (CurrentUser == null) return NotFound("User not found");

            var userId = CurrentUser.Id;

            UserBadges = await _db.UserBadges
                .Where(ub => ub.UserId == userId)
                .Include(ub => ub.Badge)
                .ToListAsync();

            Posts = await _db.Posts
                .Where(p => p.UserId == userId)
                .Include(l => l.Likes)
                .Include(c => c.Comments)
                .OrderBy(d => d.DateOfCreation)
                .ToListAsync();


            float distanceGoal = CurrentUser.Daily_Distance_Goal ?? 0;

            if (Latitude == null || Longitude == null || distanceGoal <= 0)
            {
                TempData["StatusMessage"] = "Coordinates or DailyDistanceGoal not set!";
                return RedirectToPage();
            }

            try
            {
                var client = _http.CreateClient();
                // Ob?ine p�n? la 10 obiective �n cerc cu raza mai mare pentru filtrare
                string url = $"https://api.geoapify.com/v2/places?categories=tourism.sights&filter=circle:{Longitude},{Latitude},{distanceGoal * 2000}&limit=10&apiKey={_geoapifyKey}";

                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                using var doc = await JsonDocument.ParseAsync(stream);

                // Ini?ializeaz? valori implicite
                LocationOfTheDay = "No suitable location found";
                TouristAddress = "";
                TouristLatitude = null;
                TouristLongitude = null;

                if (doc.RootElement.TryGetProperty("features", out JsonElement features) && features.GetArrayLength() > 0)
                {
                    foreach (var feature in features.EnumerateArray())
                    {
                        var props = feature.GetProperty("properties");
                        var geometry = feature.GetProperty("geometry");
                        var coords = geometry.GetProperty("coordinates");
                        double locLon = coords[0].GetDouble();
                        double locLat = coords[1].GetDouble();

                        // Distan?a fa?? de user
                        double distKm = GetDistanceKm(Latitude.Value, Longitude.Value, locLat, locLon);

                        // Verific?m dac? distan?a este aproximativ DailyDistanceGoal (�1 km)
                        if (Math.Abs(distKm - distanceGoal) <= 1.0)
                        {
                            LocationOfTheDay = props.GetProperty("name").GetString() ?? "Unknown location";
                            TouristAddress = props.TryGetProperty("formatted", out JsonElement formatted)
                                ? formatted.GetString()
                                : "Address unavailable";
                            TouristLatitude = locLat;
                            TouristLongitude = locLon;
                            break;
                        }
                    }
                }
            }
            catch
            {
                LocationOfTheDay = "Error fetching location!";
                TouristAddress = "";
                TouristLatitude = null;
                TouristLongitude = null;
            }

            DailyDistanceGoal = CurrentUser.Daily_Distance_Goal;
            TotalPoints = CurrentUser.TotalPoints;
            Level = CurrentUser.Level;

            return Page();
        }



        public async Task<IActionResult> OnPostDeletePostAsync(Guid postId)
        {
            var post = await _db.Posts
                .Include(p => p.Comments)
                .Include(p => p.Likes)
                .FirstOrDefaultAsync(p => p.Id == postId);

            if (post == null)
                return NotFound();

            _db.Comments.RemoveRange(post.Comments);
            _db.Likes.RemoveRange(post.Likes);
            _db.Posts.Remove(post);

            await _db.SaveChangesAsync();

            TempData["StatusMessage"] = "Post deleted successfully.";
            return RedirectToPage();
        }

    }
}
