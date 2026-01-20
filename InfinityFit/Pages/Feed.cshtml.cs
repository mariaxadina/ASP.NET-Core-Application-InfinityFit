using InfinityFit.Data;
using InfinityFit.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InfinityFit.Pages
{
    public class FeedModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public FeedModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Post> Posts { get; set; } = new();

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
    }
}
