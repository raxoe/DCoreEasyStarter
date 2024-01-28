using EasyStarter.MVCClient.APIServices;
using EasyStarter.MVCClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EasyStarter.MVCClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherApiService _weatherApiService;

        public HomeController(ILogger<HomeController> logger, IWeatherApiService weatherApiService)
        {
            _logger = logger;
            _weatherApiService = weatherApiService;
        }

        public IActionResult Index()
        {
            var apiData = _weatherApiService.GetWeatherAsync();
            //return Ok(new ApiResponse<ApiResponseModel> { Success = true, Data = apiData });
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
