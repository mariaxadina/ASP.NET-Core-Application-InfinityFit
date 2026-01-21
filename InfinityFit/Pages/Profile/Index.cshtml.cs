using InfinityFit.Data;
using InfinityFit.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InfinityFit.Pages.Profile
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _db;

        public IndexModel(UserManager<User> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public User ProfileUser { get; set; }
        public IList<UserBadge> UserBadges { get; set; } = new List<UserBadge>();
        public IList<Post> Posts { get; set; } = new List<Post>();

        public async Task<IActionResult> OnGetAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                return NotFound();

            ProfileUser = await _userManager.Users
                .FirstOrDefaultAsync(u => u.UserName == username);

            if (ProfileUser == null)
                return NotFound();

            UserBadges = await _db.UserBadges
                .Where(ub => ub.UserId == ProfileUser.Id)
                .Include(ub => ub.Badge)
                .ToListAsync();

            Posts = await _db.Posts
                .Where(p => p.UserId == ProfileUser.Id)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .OrderByDescending(p => p.DatePosted)
                .ToListAsync();

            return Page();
        }
    }
}
