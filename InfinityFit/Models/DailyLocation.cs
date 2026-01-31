namespace InfinityFit.Models
{
    public class DailyLocation
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public DateTime Date { get; set; }
    }
}
