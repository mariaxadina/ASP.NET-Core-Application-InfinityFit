namespace InfinityFit.Models
{
    public class DailySpinPlay
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public DateTime PlayDate { get; set; }

        public int PointsWon { get; set; } // 0, 1, 2 sau 5
    }
}
