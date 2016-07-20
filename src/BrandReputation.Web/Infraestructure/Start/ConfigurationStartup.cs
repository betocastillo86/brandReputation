using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BrandReputation.Data;

namespace BrandReputation.Web.Infraestructure.Start
{
    public static class ConfigurationStartup
    {
        public static void AddConfigurations(this IServiceCollection services)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var connectionStringConfig = builder.Build();
            services.AddDbContext<BrandReputationContext>(options => options.UseSqlServer(connectionStringConfig.GetConnectionString("DefaultConnection")));
        }
    }
}
