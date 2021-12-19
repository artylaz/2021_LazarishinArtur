using _2021_LazarishinArtur.Web.Domain;
using _2021_LazarishinArtur.Web.Domain.Entities;
using _2021_LazarishinArtur.Web.Domain.Repositories.Abstract;
using _2021_LazarishinArtur.Web.Domain.Repositories.EntityFramework;
using _2021_LazarishinArtur.Web.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2021_LazarishinArtur.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("Project", new Config());

            services.AddTransient<IHeatLossCircleDataRepository, EFHeatLossCircleDataRepository>();
            services.AddTransient<IHeatLossRectangleDataRepository, EFHeatLossRectangleDataRepository>();
            services.AddTransient<IHeatLossSquaredDataRepository, EFHeatLossSquaredDataRepository>();
            services.AddTransient<IUserRepository, EFUserRepository>();

            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionStrings.GetValueOrDefault("MsSqlServerConnection")));
            //services.AddDbContext<AppDbContext>(x => x.UseSqlite(Config.ConnectionStrings.GetValueOrDefault("SQLiteConnection")));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;

            }).AddEntityFrameworkStores<AppDbContext>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
