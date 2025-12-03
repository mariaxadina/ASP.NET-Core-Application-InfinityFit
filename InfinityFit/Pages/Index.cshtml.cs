using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InfinityFit.Models;

public class IndexModel : PageModel
{
    private readonly UserManager<User> _userManager;
    public List<User> Users { get; set; } = new();

    public IndexModel(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    public void OnGet()
    {
        Users = _userManager.Users.ToList();
    }
}
