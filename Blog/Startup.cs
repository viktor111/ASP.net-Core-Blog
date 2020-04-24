using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blog.Services;
using Blog.ViewModels;
using Blog.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using ReflectionIT.Mvc.Paging;

namespace Blog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("PcConnection")));

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddRoles<IdentityRole>()                             
                .AddEntityFrameworkStores<BlogDbContext>();

            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });

            services.AddAuthorization(options =>
            {
            options.AddPolicy("NotBanned", policy =>
                policy.
                RequireRole("User","Admin"));                    
            });

            services.AddPaging(options => {
                options.ViewName = "Bootstrap4";
            });

            services.AddControllersWithViews();

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            services.AddRazorPages();          
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IArticleData, SqlArticleData>();
            services.AddScoped<IAdmin, SqlAdminData>();
            services.AddScoped<IPreview, IndexPreview>();
            services.AddScoped<ICommentData, SqlCommentData>();
            services.AddSingleton<HttpClient>();
            services.AddScoped<ITools, Tools>();
            services.AddScoped<IProjectData, SqlProjectData>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/PageNotFound");             
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //           "forumCategory",
                //           "f/{name:minlength(3)}",
                //           new { controller = "Home", action = "Details" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");               
                endpoints.MapRazorPages();

            });
        }
    }
}
