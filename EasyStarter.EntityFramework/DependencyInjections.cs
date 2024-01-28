using EasyStarter.EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStarter.EntityFramework
{
    public static class DependencyInjections
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
        {
            //services.AddDbContext<DbShoppingContext>(options =>
            //    options.UseSqlServer("name=ConnectionStrings:DBShoppingConnectionString",
            //    x => x.MigrationsAssembly("EasyStarter.EntityFramework")));
            services.AddDbContext<DbShoppingContext>(options =>
                options.UseSqlServer("name=ConnectionStrings:DBShoppingConnectionString"));

            services.AddDatabaseDeveloperPageExceptionFilter();

        }

        public static void MigrateDatabase(IServiceScope scope)
        {            
            var dbContextOptions = scope.ServiceProvider.GetRequiredService<DbShoppingContext>();

            dbContextOptions.Database.Migrate();
            
        }

        public static void DbEnsureCreate(IServiceScope scope)
        {
            var context = scope.ServiceProvider.GetRequiredService<DbShoppingContext>();
            context.Database.EnsureCreated();

            DbInitializer.Initialize(context);
        }
    }
}
