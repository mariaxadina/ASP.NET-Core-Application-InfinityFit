using InfinityFit.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InfinityFit.Pages.Map
{
    public class MapModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public MapModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<JsonResult> OnGetNearbyPhotosAsync(double lat, double lon)
        {
            double radiusKm = 1;

            double latRange = radiusKm / 111.0;
            double lonRange = radiusKm / (111.0 * Math.Cos(lat * Math.PI / 180.0));

            var posts = await _context.Posts
                .Include(p => p.Likes)
                .Where(p =>
                    Math.Abs(p.Latitude - lat) <= latRange &&
                    Math.Abs(p.Longitude - lon) <= lonRange)
                .OrderByDescending(p => p.Likes.Count)
                .Select(p => new
                {
                    p.Id,
                    p.Title,
                    p.ImagePath,
                    p.Latitude,
                    p.Longitude,
                    LikesCount = p.Likes.Count
                })
                .ToListAsync();

            return new JsonResult(posts);
        }
    }
}
