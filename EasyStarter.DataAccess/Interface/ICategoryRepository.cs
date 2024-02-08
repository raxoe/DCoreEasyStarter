using EasyStarter.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStarter.DataAccess.Interface
{
    public interface ICategoryRepository
    {
        void AddCategory(CategoryModel categoryModel);
        //IEnumerable<CategoryModel> GetAllCategories();
        IEnumerable<CategoryViewModel> GetAllCategories();
        CategoryModel GetCategory(int id);
        void Update(CategoryModel categoryModel);
        void Delete(int id);
    }
}
