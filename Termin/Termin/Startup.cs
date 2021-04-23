using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Termin.Data;
using Termin.Data.Repositories;
using Termin.Models;

namespace Termin
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(/*options => options.SignIn.RequireConfirmedAccount = true*/)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<UserRepository>();
            services.AddTransient<RoleRepository>();
            services.AddTransient<TestRepository>();
            services.AddTransient<QuestionRepository>();

            services.AddAuthorization(option =>
            {
                option.AddPolicy("AdminRole", policy =>
                policy.RequireRole("Admin"));
            });
            services.AddAuthorization(option =>
            {
                option.AddPolicy("TeacherRole", policy =>
                policy.RequireRole("Teacher"));
            });
            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeAreaFolder("Admin","/Users", "AdminRole");
                options.Conventions.AuthorizePage("/Tests");
                options.Conventions.AuthorizeAreaFolder("Teacher","/Tests", "TeacherRole");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
