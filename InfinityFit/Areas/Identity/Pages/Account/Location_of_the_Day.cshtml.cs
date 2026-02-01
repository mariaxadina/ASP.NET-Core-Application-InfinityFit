using InfinityFit.Data;
using InfinityFit.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace InfinityFit.Areas.Identity.Pages.Account
{
    public class Location_of_the_DayModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpClientFactory _http;
        private readonly string _geoapifyKey;
        private readonly ApplicationDbContext _db;

        public Location_of_the_DayModel(
            UserManager<User> userManager,
            IHttpClientFactory http,
            IOptions<InfinityFit.Options.Geoapify> geoapifyOptions,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _http = http;
            _geoapifyKey = geoapifyOptions.Value.ApiKey;
            _db = db;
        }

        public DailyLocation? TodayLocation { get; set; }

        [BindProperty]
        public float? DailyDistanceGoal { get; set; }

        [BindProperty]
        public double? Latitude { get; set; }

        [BindProperty]
        public double? Longitude { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                DailyDistanceGoal = user.Daily_Distance_Goal;

                TodayLocation = await _db.DailyLocations
                    .FirstOrDefaultAsync(l => l.UserId == user.Id && l.Date == DateTime.UtcNow.Date);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            user.Daily_Distance_Goal = DailyDistanceGoal;
            await _userManager.UpdateAsync(user);

            TempData["StatusMessage"] = "Distance goal updated.";
            return RedirectToPage();
        }

        public static double GetDistanceKm(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371;
            var dLat = (lat2 - lat1) * Math.PI / 180;
            var dLon = (lon2 - lon1) * Math.PI / 180;

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(lat1 * Math.PI / 180) *
                    Math.Cos(lat2 * Math.PI / 180) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        public async Task<IActionResult> OnPostGetLocationAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            var existing = await _db.DailyLocations
                .FirstOrDefaultAsync(l => l.UserId == user.Id && l.Date == DateTime.UtcNow.Date);

            if (existing != null)
            {
                TodayLocation = existing;
                return Page();
            }

            if (Latitude == null || Longitude == null || user.Daily_Distance_Goal == null)
            {
                TempData["StatusMessage"] = "Location or distance goal missing.";
                return RedirectToPage();
            }

            var client = _http.CreateClient();

            string url =
                $"https://api.geoapify.com/v2/places?categories=tourism.sights" +
                $"&filter=circle:{Longitude},{Latitude},{user.Daily_Distance_Goal * 2000}" +
                $"&limit=20&apiKey={_geoapifyKey}";

            var response = await client.GetAsync(url);
            using var stream = await response.Content.ReadAsStreamAsync();
            using var doc = await JsonDocument.ParseAsync(stream);

            foreach (var feature in doc.RootElement.GetProperty("features").EnumerateArray())
            {
                var props = feature.GetProperty("properties");
                var coords = feature.GetProperty("geometry").GetProperty("coordinates");

                double lon = coords[0].GetDouble();
                double lat = coords[1].GetDouble();

                double dist = GetDistanceKm(Latitude.Value, Longitude.Value, lat, lon);

                if (Math.Abs(dist - user.Daily_Distance_Goal.Value) <= 1)
                {
                    var location = new DailyLocation
                    {
                        UserId = user.Id,
                        Name = props.GetProperty("name").GetString() ?? "Unknown",
                        Address = props.GetProperty("formatted").GetString() ?? "Unknown",
                        Latitude = lat,
                        Longitude = lon,
                        Date = DateTime.UtcNow.Date
                    };

                    _db.DailyLocations.Add(location);
                    await _db.SaveChangesAsync();

                    TodayLocation = location;
                    return Page();
                }
            }

            TempData["StatusMessage"] = "No suitable location found.";
            return RedirectToPage();
        }
    }
}
