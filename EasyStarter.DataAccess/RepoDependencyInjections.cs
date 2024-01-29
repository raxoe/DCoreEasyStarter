using EasyStarter.DataAccess.Implementation;
using EasyStarter.DataAccess.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStarter.DataAccess
{
    public class RepoDependencyInjections
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
