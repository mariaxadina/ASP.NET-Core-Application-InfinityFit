using InfinityFit.Data;
using InfinityFit.Models;
using Microsoft.EntityFrameworkCore;

namespace InfinityFit.Services
{
    public class MonthlyChallengeService
    {
        private readonly ApplicationDbContext _db;

        public MonthlyChallengeService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> GetMonthlyProgressAsync(string userId)
        {
            var monthStart = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);

            var posts = await _db.Posts
                .Where(p => p.UserId == userId && p.DatePosted >= monthStart)
                .OrderBy(p => p.DatePosted)
                .ToListAsync();

            List<Post> distinctLocations = new();

            foreach (var post in posts)
            {
                if (!distinctLocations.Any(p =>
                    GetDistanceKm(
                        p.Latitude, p.Longitude,
                        post.Latitude, post.Longitude
                    ) < 0.2)) // 200m
                {
                    distinctLocations.Add(post);
                }
            }

            return distinctLocations.Count;
        }

        private static double GetDistanceKm(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371;
            var dLat = (lat2 - lat1) * Math.PI / 180.0;
            var dLon = (lon2 - lon1) * Math.PI / 180.0;

            var a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(lat1 * Math.PI / 180.0) *
                Math.Cos(lat2 * Math.PI / 180.0) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }
    }
}
