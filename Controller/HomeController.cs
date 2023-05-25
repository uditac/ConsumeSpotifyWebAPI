using ConsumeSpotifyWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeSpotifyWebAPI.Controller;

public class HomeController : ControllerBase
{
    
    public readonly ISpotifyServices _spotifyServices;

    public readonly IConfiguration _configuration;
    public HomeController(ISpotifyServices spotifyServices, IConfiguration configuration)
    { 
        _spotifyServices = spotifyServices;
    } 

    public async Task<IActionResult> Index()
    {
        try
        {
           var token = await  _spotifyServices.GetSpotifyToken(_configuration["Spotify:ClientID"], _configuration["Spotify:ClientSecret"]);
        }
       catch (Exception ex) { }

        return View();
       
    }

    private IActionResult View()
    {
        throw new NotImplementedException();
    }
}
