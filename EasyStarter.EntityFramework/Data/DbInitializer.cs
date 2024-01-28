using EasyStarter.EntityFramework.EntityModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStarter.EntityFramework.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DbShoppingContext context)
        {
            // Look for any students.
            if (context.Categories.Any())
            {
                return;   // DB has been seeded
            }

            var mainCategories = new Category[]
            {
                new Category{Title="Electronic"},
                new Category{Title="Clothe"}
            };

            context.Categories.AddRange(mainCategories);
            context.SaveChanges();
                       
        }
    }

}
