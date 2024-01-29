using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStarter.Model.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public int? MainCategoryId { get; set; }
        public string Title { get; set; }        
    }
}
