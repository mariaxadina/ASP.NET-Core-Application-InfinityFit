using InfinityFit.Models;
using InfinityFit.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InfinityFit.Pages
{
   public class LeaderboardModel : PageModel
{
    private readonly LeaderboardService _service;

    public LeaderboardModel(LeaderboardService service)
    {
        _service = service;
    }

    public List<LeaderboardEntry> Entries { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public LeaderboardType Type { get; set; } = LeaderboardType.Popularity;

    public async Task OnGetAsync()
    {
        Entries = await _service.GetLeaderboardAsync(Type);
    }
}

}
