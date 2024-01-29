using EasyStarter.DataAccess.Interface;
using EasyStarter.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyStarter.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICategoryRepository _categoryRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            #region temp repo testing 
            //List<CategoryModel> lstCategory = _categoryRepository.GetAllCategories().ToList();

            //_categoryRepository.AddCategory(new CategoryModel() { Title = "Lenovo" });

            //_categoryRepository.Delete(2);

            //_categoryRepository.Update(new CategoryModel() { Id = 1,Title= "Electronic Update2" });
            #endregion

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
