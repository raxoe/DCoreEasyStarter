using EasyStarter.EntityFramework.EntityModel;
//using Microsoft.EntityFrameworkCore.;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStarter.EntityFramework;

public class DbShoppingContext : DbContext
{
    public DbShoppingContext(DbContextOptions<DbShoppingContext> options) : base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().ToTable("Category");
        modelBuilder.Entity<Product>().ToTable("Product");
    }

}
