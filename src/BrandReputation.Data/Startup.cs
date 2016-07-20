using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace BrandReputation.Data
{
    public class Startup
    {
        /// <summary>
        /// Permite inicializar las configuraciones
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //Habilita configuraciones con inyecciond e dependencia
            services.AddOptions();


            //Se configura la cadena de conexión para poder hacer MIGRATIONS
            //Otro enfoque podría ser http://stackoverflow.com/questions/29110241/how-do-you-configure-the-dbcontext-when-creating-migrations-in-entity-framework
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var connectionStringConfig = builder.Build();
            services.AddDbContext<BrandReputationContext>(options => options.UseSqlServer(connectionStringConfig.GetConnectionString("DefaultConnection")));
        }
    }
}
