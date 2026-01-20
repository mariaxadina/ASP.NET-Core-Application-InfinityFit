using InfinityFit.Data;
using InfinityFit.Models;
using InfinityFit.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InfinityFit.Pages
{
    public class FeedModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public FeedModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public List<Post> Posts { get; set; } = new();
        public List<Comment> Comments { get; set; } = new();
        public async Task OnGetAsync()
        {
            Posts = await _context.Posts
                .Include(p => p.User)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.User)
                .OrderByDescending(p => p.DatePosted)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostLikeAsync(Guid postId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToPage("/Account/Login", new { area = "Identity" });

            bool alreadyLiked = await _context.Likes
                .AnyAsync(l => l.PostId == postId && l.UserId == user.Id);

            if (!alreadyLiked)
            {
                var post = await _context.Posts.FindAsync(postId);
                if (post == null)
                    return NotFound();

                var like = new Like
                {
                    UserId = user.Id,
                    PostId = postId,
                    User = user,   
                    Post = post    
                };

                _context.Likes.Add(like);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    // protec?ie suplimentar? (index unic)
                }
            }

            return RedirectToPage();
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
            var post = await _context.Posts
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
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }




    }
}
