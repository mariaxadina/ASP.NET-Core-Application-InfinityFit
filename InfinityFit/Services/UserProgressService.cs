using InfinityFit.Data;
using InfinityFit.Models;
using InfinityFit.Services;
using Microsoft.EntityFrameworkCore;

public class UserProgressService
{
    private readonly ApplicationDbContext _db;
    private readonly BadgeService _badgeService;

    public UserProgressService(ApplicationDbContext db, BadgeService badgeService)
    {
        _db = db;
        _badgeService = badgeService;
    }


    public static int GetLevelForPoints(int points)
    {
        return (int)Math.Floor(Math.Sqrt(points / 100.0)) + 1;
    }


    public async Task AddPointsAsync(User user, int pointsToAdd)
    {
        user.TotalPoints ??= 0;
        user.Level ??= 1;

        user.TotalPoints += pointsToAdd;

        int newLevel = GetLevelForPoints(user.TotalPoints.Value);

        if (newLevel > user.Level)
        {
            user.Level = newLevel;
            user.LastLevelUp = DateTime.UtcNow;
        }

        _db.Users.Update(user);
        await _db.SaveChangesAsync();
        await _badgeService.CheckPostingBadgesAsync(user.Id);
    }
}
