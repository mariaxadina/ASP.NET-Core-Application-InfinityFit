namespace InfinityFit.Models
{
    public class Voucher
    {
        public int Id { get; set; } // PK
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        // FK către User
        public string? UserId { get; set; }
        public User? User { get; set; }

        // Cod unic pentru fiecare voucher primit
        public string Code { get; set; } = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
    }

}
