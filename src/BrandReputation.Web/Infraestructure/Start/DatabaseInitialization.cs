using BrandReputation.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrandReputation.Web.Infraestructure.Start
{
    public static class DatabaseInitialization
    {
        public static void InitDatabase(this IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                using (var context = (BrandReputationContext)app.ApplicationServices.GetService(typeof(BrandReputationContext)))
                {
                    context.Database.EnsureCreated();
                }
            }
        }
    }
}
