using InfinityFit.Data;
using InfinityFit.Models;
using InfinityFit.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace InfinityFit.Pages.Posts
{
    [Authorize] // doar utilizatorii logați pot crea postări
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly BadgeService _badgeService;

        public CreateModel(ApplicationDbContext context, UserManager<User> userManager, IWebHostEnvironment env, BadgeService badgeService)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
            _badgeService = badgeService;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public class InputModel
        {
            [Required]
            public string Title { get; set; }

            [Required]
            public string Description { get; set; }

            [Required]
            public IFormFile ImageFile { get; set; }


            [Required]
            public double Latitude { get; set; }

            [Required]
            public double Longitude { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized();

            string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Input.ImageFile.FileName);
            string filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await Input.ImageFile.CopyToAsync(stream);
            }

            var post = new Post
            {
                UserId = user.Id,
                User = user,
                Title = Input.Title,
                Description = Input.Description,
                ImagePath = "/uploads/" + fileName,
                Latitude = Input.Latitude,
                Longitude = Input.Longitude,
                DatePosted = DateTime.UtcNow
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            var userId = user.Id;
            await _badgeService.CheckPostingBadgesAsync(userId);

            return RedirectToPage("/Index");
        }
    }
}
