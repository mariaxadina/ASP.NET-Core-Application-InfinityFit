namespace InfinityFit.Models
{
    public class UserVoucher
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public int VoucherId { get; set; }
        public Voucher Voucher { get; set; }

        public DateTime DateObtained { get; set; } = DateTime.UtcNow;
        public bool IsRedeemed { get; set; } = false;
    }
}
