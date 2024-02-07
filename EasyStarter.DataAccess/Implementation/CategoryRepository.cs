using EasyStarter.DataAccess.Converter;
using EasyStarter.DataAccess.Interface;
using EasyStarter.EntityFramework;
using EasyStarter.EntityFramework.EntityModel;
using EasyStarter.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStarter.DataAccess.Implementation
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly DbShoppingContext _context;
        public CategoryRepository(DbShoppingContext context)
        {
            _context = context;
        }

        public void AddCategory(CategoryModel categoryModel)
        {
            Category entity=new Category();
            CategoryConverter.ConvertModelToEntity(categoryModel,ref entity);
            _context.Categories.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<CategoryModel> GetAllCategories()
        {
            CategoryModel mm = new CategoryModel();            
            return _context.Categories.Select(x => CategoryConverter.ConvertEntityToModel(x));
        }

        public CategoryModel GetCategory(int id)
        {
            return CategoryConverter.ConvertEntityToModel(_context.Categories.FirstOrDefault(x => x.Id == id));
        }

        public void Update(CategoryModel categoryModel)
        {
            Category entity=_context.Categories.FirstOrDefault(x=>x.Id==categoryModel.Id);
            if(entity != null)
            {
                CategoryConverter.ConvertModelToEntity(categoryModel,ref entity);
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Categories.Remove(_context.Categories.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
        }

    }
}
