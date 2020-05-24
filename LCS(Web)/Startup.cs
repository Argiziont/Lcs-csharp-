using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LCS_Web_.Models.Interfaces;
using LCS_Web_.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DataBaseAndLogic.DBlogic;

namespace LCS_Web_
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LocalContext>(options =>
               options.UseSqlServer(LocalContext.GetConfigurationString("appsettings.json", "DefaultConnection")));
            services.AddControllersWithViews();
            services.AddTransient<ILscString, EFLscString>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=LcsString}/{action=LcsForm}"
                    );
            });
        }
    }
}
