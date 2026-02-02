using InfinityFit.Data;
using InfinityFit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace InfinityFit.Pages
{
    [Authorize]
    public class ArcadeModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpClientFactory _http;
        private readonly ApplicationDbContext _db;

        public ArcadeModel(UserManager<User> userManager, IHttpClientFactory http, ApplicationDbContext db)
        {
            _userManager = userManager;
            _http = http;
            _db = db;
        }

        public string Question { get; set; }
        public List<string> Answers { get; set; } = new();
        public string CorrectAnswer { get; set; }
        public string Message { get; set; }

        [BindProperty]
        public string SelectedAnswer { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized();

            bool alreadyPlayed = await _db.DailyQuizPlays
                .AnyAsync(x => x.UserId == user.Id && x.PlayDate == DateTime.Today);

            if (alreadyPlayed)
            {
                Message = "You played already. Come back tomorrow! ";
                return Page();
            }

            await LoadQuestion();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string correctAnswer)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToPage("/Account/Login");

            bool alreadyPlayed = await _db.DailyQuizPlays
                .AnyAsync(x => x.UserId == user.Id && x.PlayDate == DateTime.Today);

            if (alreadyPlayed)
            {
                Message = "Ai jucat deja azi.";
                return Page();
            }

            bool isCorrect = SelectedAnswer == correctAnswer;

            var play = new DailyQuizPlay
            {
                UserId = user.Id,
                PlayDate = DateTime.Today,
                IsCorrect = isCorrect
            };

            _db.DailyQuizPlays.Add(play);

            // ? ADD POINTS IF CORRECT
            if (isCorrect)
            {
                user.TotalPoints += 5;   // <-- adjust name if needed (Score / BonusPoints etc.)
                await _userManager.UpdateAsync(user);
            }

            await _db.SaveChangesAsync();

            if (isCorrect)
                Message = "Correct! You won 5 points!";
            else
                Message = "Wrong answer! Try again tomorrow!";


            return Page();
        }

        private async Task LoadQuestion()
        {
            var client = _http.CreateClient();
            var json = await client.GetStringAsync("https://opentdb.com/api.php?amount=1&type=multiple");

            using var doc = JsonDocument.Parse(json);
            var result = doc.RootElement.GetProperty("results")[0];

            Question = System.Net.WebUtility.HtmlDecode(result.GetProperty("question").GetString());
            CorrectAnswer = System.Net.WebUtility.HtmlDecode(result.GetProperty("correct_answer").GetString());

            var incorrect = result.GetProperty("incorrect_answers")
                .EnumerateArray()
                .Select(x => System.Net.WebUtility.HtmlDecode(x.GetString()))
                .ToList();

            Answers = incorrect.Append(CorrectAnswer).OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}
