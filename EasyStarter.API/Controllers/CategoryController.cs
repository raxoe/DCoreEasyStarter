using EasyStarter.DataAccess.Interface;
using EasyStarter.EntityFramework.EntityModel;
using EasyStarter.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyStarter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ILogger<WeatherForecastController> logger, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }
        // GET: api/<ValuesController>/GetCategory
        [HttpGet]
        public IEnumerable<CategoryViewModel> GetCategory()
        {
            return _categoryRepository.GetAllCategories();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public CategoryModel GetCategory(int id)
        {
            return _categoryRepository.GetCategory(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult AddCategory(CategoryModel categoryModel)
        {
            _categoryRepository.AddCategory(categoryModel);
            return Ok();
        }

        // PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        [HttpPut()]
        public IActionResult UpdateCategory(CategoryModel categoryModel)
        {
            _categoryRepository.Update(categoryModel);
            return Ok();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
            return Ok();
        }
    }
}
