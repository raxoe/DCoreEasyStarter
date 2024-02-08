using EasyStarter.EntityFramework.EntityModel;
using EasyStarter.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStarter.DataAccess.Converter
{
    public static class CategoryConverter
    {
        public static void ConvertModelToEntity(CategoryModel model,ref Category entity)
        {
            entity.Id = model.Id;
            entity.MainCategoryId=model.MainCategoryId;
            entity.Title = model.Title;
        }

        //public static void ConvertEntityToModel(Category entity,ref CategoryModel model)
        //{
        //    model.Id=entity.Id;
        //    model.MainCategoryId = entity.MainCategoryId;
        //    model.Title = entity.Title;
        //}
        public static CategoryModel ConvertEntityToModel(Category entity)
        {
            CategoryModel model = new CategoryModel();
            model.Id = entity.Id;
            model.MainCategoryId = entity.MainCategoryId;
            model.Title = entity.Title;
            return model;
        }
        public static CategoryViewModel ConvertEntityToViewModel(Category entity)
        {
            CategoryViewModel viewModel = new CategoryViewModel();
            viewModel.Id = entity.Id;
            viewModel.MainCategoryId = entity.MainCategoryId;
            viewModel.Title = entity.Title;
            viewModel.MainCategoryTitle = entity.MainCategory !=null ? entity.MainCategory.Title : "";
            return viewModel;
        }
    }
}
