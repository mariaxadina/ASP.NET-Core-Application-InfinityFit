namespace InfinityFit.Models
{
    public class DailyQuizPlay
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public DateTime PlayDate { get; set; } // Date.Date

        public bool IsCorrect { get; set; }
    }
}
