using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStarter.Model.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public int? MainCategoryId { get; set; }
        public string Title { get; set; }
        public string MainCategoryTitle { get; set; }
    }
}
