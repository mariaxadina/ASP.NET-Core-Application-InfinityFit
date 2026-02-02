using InfinityFit.Data;
using InfinityFit.Models;
using InfinityFit.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly BadgeService _badgeService;
    private readonly UserProgressService _userProgressService;

    public IndexModel(ApplicationDbContext context, UserManager<User> userManager,
                      BadgeService badgeService, UserProgressService userProgressService)
    {
        _context = context;
        _userManager = userManager;
        _badgeService = badgeService;
        _userProgressService = userProgressService;
    }


    private const int POINTS_FOR_NEW_LIKE = 5;
    private const int POINTS_FOR_NEW_COMMENT = 10;

    public List<Comment> Comments { get; set; } = new();
    public List<Post> TopPosts { get; set; } = new();

    public async Task OnGetAsync()
    {
        // Top 3 postări cu cele mai multe like-uri
        TopPosts = await _context.Posts
            .Include(p => p.User)
            .Include(p => p.Likes)
            .Include(p => p.Comments)
            .OrderByDescending(p => p.Likes.Count) // ordonare după număr like-uri
            .Take(3) // primele 3
            .ToListAsync();
    }

    public async Task<IActionResult> OnPostLikeAsync(Guid postId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return new JsonResult(new { error = "Not logged in" }) { StatusCode = 401 };

        // Verificăm dacă user-ul a mai dat like
        var existingLike = await _context.Likes
            .FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == user.Id);

        if (existingLike != null)
        {
            // Ștergem like-ul
            _context.Likes.Remove(existingLike);
            await _userProgressService.AddPointsAsync(user, -POINTS_FOR_NEW_LIKE);
        }
        else
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null) return NotFound();

            var like = new Like
            {
                UserId = user.Id,
                PostId = postId,
                User = user,
                Post = post
            };
            _context.Likes.Add(like);
            await _userProgressService.AddPointsAsync(user, POINTS_FOR_NEW_LIKE);
            var userId = user.Id;
            await _badgeService.CheckPostingBadgesAsync(userId);
        }

        await _context.SaveChangesAsync();

        // Returnăm HTML-ul actualizat doar pentru numărul de like-uri
        var likeCount = await _context.Likes.CountAsync(l => l.PostId == postId);
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

        await _userProgressService.AddPointsAsync(user, POINTS_FOR_NEW_COMMENT);
        var userId = user.Id;
        await _badgeService.CheckPostingBadgesAsync(userId);

        return RedirectToPage();
    }
}
