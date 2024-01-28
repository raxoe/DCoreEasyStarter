using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStarter.EntityFramework.EntityModel;

public class Category
{
    public int Id { get; set; }
    public int? MainCategoryId { get; set; }
    public string Title { get; set; }
    [DisplayFormat(NullDisplayText = "No Main Category")]
    public Category MainCategory { get; set; }
    public ICollection<Product> Products { get; set; }

}
