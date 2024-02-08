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
            List<CategoryViewModel> lstModel = _categoryApiService.GetCategoryAsync().Result.Data;
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
            //List<CategoryModel> categoryModels = new List<CategoryModel>();

            //categoryModels.Add(new CategoryModel() { Id = -1, Title = "---Select MainCategory---" });
            //categoryModels.Add(new CategoryModel() { Id=1,Title="title1"});
            //categoryModels.Add(new CategoryModel() { Id = 2, Title = "title2" });
            
            //List<CategoryModel> lstCategory =  _categoryApiService.GetCategoryAsync().Result.Data;
            //lstCategory=lstCategory.Prepend(new CategoryModel() { Id = -1, Title = "---Select MainCategory---" }).ToList();

            //ViewBag.MainCategory =new SelectList(lstCategory.ToDictionary(us => us.Id, us => us.Title), "Key", "Value");

            ViewBag.MainCategory = BindCategoryDropdown(0);

            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryModel model)
        {
            try
            {
                var result = _categoryApiService.AddCategoryAsync(model).Result.Data;
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
            CategoryModel category = _categoryApiService.GetCategoryAsync(id).Result.Data;

            if (category.MainCategoryId != null)
            {
                ViewBag.MainCategory = BindCategoryDropdown((int)category.MainCategoryId);
            }
            else
            {
                ViewBag.MainCategory = BindCategoryDropdown(0);
            }           

            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        public ActionResult Edit(CategoryModel categoryModel)
        {
            try
            {
                CategoryModel category = _categoryApiService.UpdateCategoryAsync(categoryModel).Result.Data;

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

        #region private method
        private SelectList BindCategoryDropdown(int selectedID)
        {
            List<CategoryViewModel> lstCategory = _categoryApiService.GetCategoryAsync().Result.Data;
            lstCategory = lstCategory.Prepend(new CategoryViewModel() { Id = -1, Title = "---Select MainCategory---" }).ToList();

            if (selectedID != 0) {
                return new SelectList(lstCategory.ToDictionary(us => us.Id, us => us.Title), "Key", "Value", selectedID);
            }
            else
            {
                return new SelectList(lstCategory.ToDictionary(us => us.Id, us => us.Title), "Key", "Value");
            }
            return null;
        }
        #endregion
    }
}
