using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InfinityFit.Models;
using System.Threading.Tasks;

namespace InfinityFit.Areas.Identity.Pages.Account.Manage
{
    public class CustomProfileModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public CustomProfileModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // The currently logged-in user
        public User CurrentUser { get; set; }

        // Bindable property for DailyDistanceGoal so the form can update it
        [BindProperty]
        public float? DailyDistanceGoal { get; set; }

        [BindProperty]
        public int? TotalPoints { get; set; } // optional if you want to show/update

        [BindProperty]
        public int? Level { get; set; }
        [BindProperty]
        public double? Latitude { get; set; }

        [BindProperty]
        public double? Longitude { get; set; }
        public async Task OnGetAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);

            if (CurrentUser != null)
            {
                DailyDistanceGoal = CurrentUser.Daily_Distance_Goal;
                TotalPoints = CurrentUser.TotalPoints;
                Level = CurrentUser.Level;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            CurrentUser = await _userManager.GetUserAsync(User);

            if (CurrentUser == null)
            {
                return NotFound("User not found");
            }

            // Update the daily distance goal
            CurrentUser.Daily_Distance_Goal = DailyDistanceGoal;

            // Optionally update other fields here (TotalPoints, Level etc.)

            var result = await _userManager.UpdateAsync(CurrentUser);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            TempData["StatusMessage"] = "Profile updated successfully!";
            return RedirectToPage(); // Reload the page
        }
    }
}
