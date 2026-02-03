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
    private readonly MonthlyChallengeService _monthlyChallengeService;

    public IndexModel(
        ApplicationDbContext context,
        UserManager<User> userManager,
        BadgeService badgeService,
        UserProgressService userProgressService,
        MonthlyChallengeService monthlyChallengeService)
    {
        _context = context;
        _userManager = userManager;
        _badgeService = badgeService;
        _userProgressService = userProgressService;
        _monthlyChallengeService = monthlyChallengeService;
    }

    private const int POINTS_FOR_NEW_LIKE = 5;
    private const int POINTS_FOR_NEW_COMMENT = 10;

    public List<Comment> Comments { get; set; } = new();
    public List<Post> TopPosts { get; set; } = new();

    // 🔥 CHALLENGE DATA
    public int MonthlyProgress { get; set; }
    

    public async Task OnGetAsync()
    {
        // 🔥 Top posts
        TopPosts = await _context.Posts
            .Include(p => p.User)
            .Include(p => p.Likes)
            .Include(p => p.Comments)
            .OrderByDescending(p => p.Likes.Count)
            .Take(3)
            .ToListAsync();

        // 🔥 Monthly challenge progress
        if (User.Identity?.IsAuthenticated == true)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                MonthlyProgress = await _monthlyChallengeService
                    .GetMonthlyProgressAsync(user.Id);
            }
        }
    }

    public async Task<IActionResult> OnPostLikeAsync(Guid postId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return new JsonResult(new { error = "Not logged in" }) { StatusCode = 401 };

        var existingLike = await _context.Likes
            .FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == user.Id);

        if (existingLike != null)
        {
            _context.Likes.Remove(existingLike);
            await _userProgressService.AddPointsAsync(user, -POINTS_FOR_NEW_LIKE);
        }
        else
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null) return NotFound();

            _context.Likes.Add(new Like
            {
                UserId = user.Id,
                PostId = postId,
                User = user,
                Post = post
            });

            await _userProgressService.AddPointsAsync(user, POINTS_FOR_NEW_LIKE);
            await _badgeService.CheckPostingBadgesAsync(user.Id);
        }

        await _context.SaveChangesAsync();

        var likeCount = await _context.Likes.CountAsync(l => l.PostId == postId);
        return Content($"<span id=\"like-count-{postId}\">{likeCount}</span>", "text/html");
    }

    public async Task<IActionResult> OnPostCommentAsync(
        Guid postId,
        string content,
        [FromServices] CommentModerationService moderation)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return RedirectToPage("/Account/Login", new { area = "Identity" });

        bool isSafe = await moderation.IsSafeAsync(content);
        if (!isSafe)
        {
            TempData["CommentError"] = "Your comment was rejected.";
            return RedirectToPage();
        }

        var post = await _context.Posts
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == postId);

        if (post == null) return NotFound();

        _context.Comments.Add(new Comment
        {
            Content = content,
            UserId = user.Id,
            PostId = post.Id,
            User = user,
            Post = post
        });

        await _context.SaveChangesAsync();
        await _userProgressService.AddPointsAsync(user, POINTS_FOR_NEW_COMMENT);
        await _badgeService.CheckPostingBadgesAsync(user.Id);

        return RedirectToPage();
    }
}
