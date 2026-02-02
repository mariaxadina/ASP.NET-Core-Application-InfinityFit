using InfinityFit.Data;
using InfinityFit.Models;
using InfinityFit.Services;
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
        private readonly UserProgressService _userProgressService;
        private readonly BadgeService _badgeService;

        public CustomProfileModel(UserManager<User> userManager, IHttpClientFactory http, 
                                  IOptions<InfinityFit.Options.Geoapify> geoapifyOptions, 
                                  UserProgressService userProgressService, 
                                  BadgeService badgeService, ApplicationDbContext db)
        {
            _userManager = userManager;
            _http = http;
            _geoapifyKey = geoapifyOptions.Value.ApiKey;
            _userProgressService = userProgressService;
            _badgeService = badgeService;
            _db = db;
        }

        private const int POINTS_FOR_NEW_LIKE = 5;
        private const int POINTS_FOR_NEW_COMMENT = 10;


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
                .OrderByDescending(d => d.DateAwarded)
                .ToListAsync();

            Posts = await _db.Posts
                .Where(p => p.UserId == userId)
                .Include(l => l.Likes)
                .Include(c => c.Comments)
                .OrderByDescending(d => d.DateOfCreation)
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



        public async Task<IActionResult> OnPostLikeAsync(Guid postId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return new JsonResult(new { error = "Not logged in" }) { StatusCode = 401 };

            // Verificăm dacă user-ul a mai dat like
            var existingLike = await _db.Likes
                .FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == user.Id);

            if (existingLike != null)
            {
                // Ștergem like-ul
                _db.Likes.Remove(existingLike);
                await _userProgressService.AddPointsAsync(user, -POINTS_FOR_NEW_LIKE);
            }
            else
            {
                var post = await _db.Posts.FindAsync(postId);
                if (post == null) return NotFound();

                var like = new Like
                {
                    UserId = user.Id,
                    PostId = postId,
                    User = user,
                    Post = post
                };
                _db.Likes.Add(like);
                await _userProgressService.AddPointsAsync(user, POINTS_FOR_NEW_LIKE);
                var userId = user.Id;
                await _badgeService.CheckPostingBadgesAsync(userId);
            }

            await _db.SaveChangesAsync();

            // Returnăm HTML-ul actualizat doar pentru numărul de like-uri
            var likeCount = await _db.Likes.CountAsync(l => l.PostId == postId);
            return Content($"<span id=\"like-count-{postId}\">{likeCount}</span>", "text/html");
        }

        public async Task<IActionResult> OnPostCommentAsync(Guid postId, string content, [FromServices] CommentModerationService moderation)
        {
            // 1?? Ob?ine utilizatorul logat
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToPage("/Account/Login", new { area = "Identity" });

            // 2?? Verific?m comentariul prin AI
            bool isSafe = await moderation.IsSafeAsync(content);

            if (!isSafe)
            {
                TempData["CommentError"] = " Your comment was rejected because it violates our guidelines.";
                return RedirectToPage();
            }






            // 3?? Ob?ine postarea din DB (trebuie neap?rat pentru proprietatea 'Post')
            var post = await _db.Posts
                .Include(p => p.Comments)   // op?ional, dac? vrei lista de comentarii imediat
                .Include(p => p.User)       // necesar pentru Post.User dac? e required
                .FirstOrDefaultAsync(p => p.Id == postId);

            if (post == null)
                return NotFound("Post not found");

            // 4?? Creeaz? comentariul COMPLET, cu toate propriet??ile required setate
            var comment = new Comment
            {
                Content = content,
                UserId = user.Id,
                PostId = post.Id,
                User = user,
                Post = post
            };

            // 5?? Adaug? ?i salveaz? în DB
            _db.Comments.Add(comment);
            await _db.SaveChangesAsync();

            await _userProgressService.AddPointsAsync(user, POINTS_FOR_NEW_COMMENT);
            var userId = user.Id;
            await _badgeService.CheckPostingBadgesAsync(userId);

            return RedirectToPage();
        }


    }
}
