using InfinityFit.Data;
using InfinityFit.Models;
using Microsoft.EntityFrameworkCore;

namespace InfinityFit.Services
{
    public class BadgeService
    {
        private readonly ApplicationDbContext _db;

        public BadgeService(ApplicationDbContext db)
        {
            _db = db;
        }

        // Verifica daca userul are badge-ul
        public async Task<bool> UserHasBadgeAsync(string userId, Guid badgeId)
        {
            return await _db.UserBadges
                .AnyAsync(ub => ub.UserId == userId && ub.BadgeId == badgeId);
        }

        // Ofera un badge pe baza ID-ului
        public async Task AwardBadgeAsync(string userId, Guid badgeId)
        {
            // Nu da badge dacă deja există
            if (await UserHasBadgeAsync(userId, badgeId))
                return;

            var ub = new UserBadge
            {
                UserId = userId,
                BadgeId = badgeId,
                DateAwarded = DateTime.UtcNow
            };

            _db.UserBadges.Add(ub);
            await _db.SaveChangesAsync();
        }

        // Ofera un badge dupa nume
        public async Task AwardBadgeByNameAsync(string userId, string badgeName)
        {
            var badge = await _db.Badges
                .FirstOrDefaultAsync(b => b.Name == badgeName);

            if (badge == null)
                return; // nu exista badge-ul

            await AwardBadgeAsync(userId, badge.Id);
        }

        // Exemplu simplu: badge-uri in functie de nr. de postari
        public async Task CheckPostingBadgesAsync(string userId)
        {
            await AwardBadgeByNameAsync(userId, "Welcome");

            int postCount = await _db.Posts
                .CountAsync(p => p.UserId == userId);

            if (postCount >= 1)
                await AwardBadgeByNameAsync(userId, "First Post");

            if (postCount >= 5)
                await AwardBadgeByNameAsync(userId, "Traveler");

            if (postCount >= 20)
                await AwardBadgeByNameAsync(userId, "Explorer");
        }
    }
}
