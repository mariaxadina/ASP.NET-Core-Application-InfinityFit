using InfinityFit.Data;
using InfinityFit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.DotNet.MSIdentity.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace InfinityFit.Pages.Map
{
    public class MapModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _http;
        private readonly  IConfiguration _config ; 

        public MapModel(ApplicationDbContext context, IConfiguration config, IHttpClientFactory http)
        {
            _context = context;
            _config =  config;
            _http = http;

        }

        public List<Post> NearbyPhotos { get; set; } = new List<Post>();

        public async Task<IActionResult> OnGetAsync(double? lat, double? lon)
        {
            if (lat.HasValue && lon.HasValue)
            {
                const double maxDistanceKm = 1000;//1km
                double latRange = maxDistanceKm / 111.0;
                double lonRange = maxDistanceKm / (111.0 * Math.Cos(lat.Value * Math.PI / 180.0));

                NearbyPhotos = await _context.Posts
                    .Where(p =>
                        Math.Abs(p.Latitude - lat.Value) <= latRange &&
                        Math.Abs(p.Longitude - lon.Value) <= lonRange)
                    .ToListAsync();
            }
            return Page();
     
        }
        public async Task<JsonResult> OnGetNearbyPlacesAsync(double lat, double lon)
        {
            var dist = 1000; //1km
            var apiKey = _config["Geoapify:ApiKey"];

            var url = $"https://api.geoapify.com/v2/places?categories=tourism.sights&filter=circle:{lon},{lat},{dist}&apiKey={apiKey}";


            using var client = _http.CreateClient();
            var result = await client.GetFromJsonAsync<object>(url);
            return new JsonResult(result);
        }


        
    }
   


}
