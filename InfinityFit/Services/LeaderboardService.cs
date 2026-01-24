using InfinityFit.Data;
using InfinityFit.Models;
using Microsoft.EntityFrameworkCore;

namespace InfinityFit.Services
{
   public class LeaderboardService
{
    private readonly ApplicationDbContext _db;

    public LeaderboardService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<List<LeaderboardEntry>> GetLeaderboardAsync(
        LeaderboardType type,
        int top = 10)
    {
        var oneMonthAgo = DateTime.UtcNow.AddMonths(-1);

        return type switch
        {
            LeaderboardType.Popularity => await GetPopularityLeaderboard(oneMonthAgo, top),
            LeaderboardType.Activity => await GetActivityLeaderboard(oneMonthAgo, top),
            _ => new List<LeaderboardEntry>()
        };
    }

    // 🔥 POPULARITATE (like-uri + comentarii PRIMITE)
    private async Task<List<LeaderboardEntry>> GetPopularityLeaderboard(DateTime from, int top)
    {
        var likes = _db.Likes
            .Where(l => l.Post.DatePosted >= from)
            .GroupBy(l => l.Post.UserId)
            .Select(g => new { UserId = g.Key, Count = g.Count() });

        var comments = _db.Comments
            .Where(c => c.Post.DatePosted >= from)
            .GroupBy(c => c.Post.UserId)
            .Select(g => new { UserId = g.Key, Count = g.Count() });

        var engagement = likes
            .Concat(comments)
            .GroupBy(x => x.UserId)
            .Select(g => new
            {
                UserId = g.Key,
                Engagement = g.Sum(x => x.Count)
            })
            .OrderByDescending(x => x.Engagement)
            .Take(top);

        var result = await engagement
            .Join(_db.Users,
                  e => e.UserId,
                  u => u.Id,
                  (e, u) => new LeaderboardEntry
                  {
                      UserId = u.Id,
                      User = u,
                      Engagement= e.Engagement
                  })
            .ToListAsync();

        return result;
    }

    // ⚡ ACTIVITATE (like-uri + comentarii DATE)
    private async Task<List<LeaderboardEntry>> GetActivityLeaderboard(DateTime from, int top)
    {
        var likes = _db.Likes
            .Where(l => l.Date >= from)
            .GroupBy(l => l.UserId)
            .Select(g => new { UserId = g.Key, Count = g.Count() });

        var comments = _db.Comments
            .Where(c => c.Date >= from)
            .GroupBy(c => c.UserId)
            .Select(g => new { UserId = g.Key, Count = g.Count() });

        var engagement = likes
            .Concat(comments)
            .GroupBy(x => x.UserId)
            .Select(g => new
            {
                UserId = g.Key,
                Engagement = g.Sum(x => x.Count)
            })
            .OrderByDescending(x => x.Engagement)
            .Take(top);

        var result = await engagement
            .Join(_db.Users,
                  e => e.UserId,
                  u => u.Id,
                  (e, u) => new LeaderboardEntry
                  {
                      UserId = u.Id,
                      User = u,
                      Engagement = e.Engagement
                  })
            .ToListAsync();

        return result;
    }
}

}
