using EasyStarter.Model.Models;
using EasyStarter.MVCClient.APIServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyStarter.MVCClient.Controllers
{
    public class CategoryController : Controller
    {
        private ILogger<HomeController> _logger;

        public ICategoryApiService _categoryApiService { get; }

        public CategoryController(ILogger<HomeController> logger, ICategoryApiService categoryApiService)
        {
            _logger = logger;
            _categoryApiService = categoryApiService;
        }

        // GET: CategoryController
        public async Task<ActionResult> Index()
        {

            var result =await _categoryApiService.GetCategoryAsync();
            List<CategoryModel> lstModel = result.Data;
            return View(lstModel);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            List<CategoryModel> categoryModels = new List<CategoryModel>();

            categoryModels.Add(new CategoryModel() { Id = 0, Title = "---Select MainCategory" });
            categoryModels.Add(new CategoryModel() { Id=1,Title="title1"});
            categoryModels.Add(new CategoryModel() { Id = 2, Title = "title2" });             

            ViewBag.MainCategory =new SelectList(categoryModels.ToDictionary(us => us.Id, us => us.Title), "Key", "Value");

            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryModel model)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
