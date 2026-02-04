using InfinityFit.Data;
using InfinityFit.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InfinityFit.Areas.Identity.Pages.Account
{
    public class VouchersModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _db;

        public VouchersModel(UserManager<User> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public List<Voucher> UserVouchers { get; set; } = new();

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                UserVouchers = await _db.Vouchers
                    .Where(v => v.UserId == user.Id)
                    .OrderByDescending(v => v.Id)
                    .ToListAsync();
            }
        }
    }
}
