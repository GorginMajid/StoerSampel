using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreSampel.Application.Contracts;
using StoreSampel.Application.UnitOfWork;
using StoreSampel.Domain.Identity;
using StoreSampel.Persistence.Context;

namespace StoreSampel.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

           

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                //options.AccessDeniedPath = "/Home/AccessDenied";
            });
            services.AddDbContext<StoreSampelContext>(opt =>
                {
                    opt.UseSqlServer(Configuration.GetConnectionString("StoreSampel"));
                });

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddIdentity<ApplicationUser, ApplicationRole>(
                    options =>
                    {
                        //Configure Password
                        options.Password.RequireDigit = false;
                        options.Password.RequiredLength = 6;
                        options.Password.RequiredUniqueChars = 1;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireUppercase = false;

                        options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                        options.User.RequireUniqueEmail = true;

                        options.SignIn.RequireConfirmedEmail = false;

                        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
                        options.Lockout.MaxFailedAccessAttempts = 3;
                    })
                .AddEntityFrameworkStores<StoreSampelContext>()
                .AddErrorDescriber<ApplicationIdentityErrorDescriber>()
                .AddDefaultTokenProviders();



            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
