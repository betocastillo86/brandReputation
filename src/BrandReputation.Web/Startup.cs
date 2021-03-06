﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BrandReputation.Web.Infraestructure.Start;

namespace BrandReputation.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Habilita configuraciones con inyecciond e dependencia
            services.AddOptions();

            //Agrega las configuraciones personalizadas
            services.AddConfigurations();
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.InitDatabase(env);

            app.UseStaticFiles();
            
            app.UseMvc(routes => {
                routes.MapRoute(
                    name:"defaultRoute",
                    template:"{controller=Home}/{action=Index}");
            });

            
            
            //loggerFactory.AddConsole();
            //
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
