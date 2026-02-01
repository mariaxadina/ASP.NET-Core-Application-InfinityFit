using InfinityFit.Data;
using InfinityFit.Models;
using InfinityFit.Services;
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
        public string LoggedInUserId { get; private set; }

        public async Task<IActionResult> OnGetAsync(string username)
        {
            LoggedInUserId = _userManager.GetUserId(User);

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


        public async Task<IActionResult> OnPostDeletePostAsync(int postId)
        {
 
            var post = await _db.Posts.FindAsync(postId);

            if (post == null)
                return NotFound();

            // userul logat
            var currentUserName = User.Identity?.Name;

            // 🔒 SECURITY CHECK
            if (post.User.UserName != currentUserName)
            {
                return Forbid(); // sau Unauthorized()
            }

            _db.Posts.Remove(post);
            await _db.SaveChangesAsync();

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

            return RedirectToPage();
        }


    }
}
