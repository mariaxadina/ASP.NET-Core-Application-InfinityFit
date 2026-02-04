using InfinityFit.Data;
using InfinityFit.Models;
using Microsoft.EntityFrameworkCore;

namespace InfinityFit.Services
{
    public class VoucherService
    {
        private readonly ApplicationDbContext _context;

        public VoucherService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Atribuie un voucher random unui user.
        /// Creează un obiect Voucher în baza de date legat de user.
        /// </summary>
        public async Task<Voucher> AssignRandomVoucherAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            // Aleg random un template din lista hardcodata
            var templates = VoucherTemplates.Templates;
            var random = new Random();
            var chosen = templates[random.Next(templates.Count)];

            // Creează voucherul în baza de date și îl leagă de user
            var voucher = new Voucher
            {
                UserId = user.Id,
                Name = chosen.Name,
                Description = chosen.Description,
            };

            _context.Vouchers.Add(voucher);
            await _context.SaveChangesAsync();

            return voucher;
        }

        /// <summary>
        /// Returnează toate voucherele unui user.
        /// </summary>
        public async Task<List<Voucher>> GetUserVouchersAsync(string userId)
        {
            return await _context.Vouchers
                .Where(v => v.UserId == userId)
                .ToListAsync();
        }
    }
}
