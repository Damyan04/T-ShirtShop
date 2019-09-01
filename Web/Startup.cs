using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TShirtShop.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI.Services;
using TShirtShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using TShirtShop.Data.Models;
using TShirtShop.Services;
using System.Security.Claims;

namespace TShirtShop
{
    public class Startup
    {
        const string AdministratorClaimType = "http://yourdomain.com/claims/administrator";

        const string AdministratorOnlyPolicy = "AdministratorOnly";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("TShirtShop.Data")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
    
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
            services.AddIdentityCore<ApplicationUser>()
                 .AddRoles<IdentityRole>()
                 .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>>()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders()
                 .AddDefaultUI();
           
            services.AddMvc(config=>
            {
                // using Microsoft.AspNetCore.Mvc.Authorization;
                // using Microsoft.AspNetCore.Authorization;
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            })
         .AddRazorPagesOptions(options =>
         {
            
             options.AllowAreas = true;
             options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
             options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
             
         }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

           
            // using Microsoft.AspNetCore.Identity.UI.Services;
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddMvc();
          
            services.AddHttpContextAccessor();
            services.AddScoped<IShopingCartService>(sp => ShopingCartService.GetCart(sp));

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IUploadFileService, UploadFileService>();
            services.AddSession();
            services.AddAuthorization(options =>
            {
                options.AddPolicy(AdministratorOnlyPolicy, policy => policy.RequireClaim(AdministratorClaimType));
            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            await CreateApplicationUsersAsync(scopeFactory);
        }
        private async Task CreateApplicationUsersAsync(IServiceScopeFactory scopeFactory)
        {
            var scope = scopeFactory.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var signInManager = scope.ServiceProvider.GetRequiredService<SignInManager<ApplicationUser>>();

            //Create admin user if not existing
            var adminUserName = "administrator@yourdomain.com";
            ApplicationUser adminUser = await userManager.FindByNameAsync(adminUserName);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminUserName,
                    Email = "administrator1@yourdomain.com",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "Adf1nbar!");
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException($"Unexpected error occurred creating new admin user in Startup.cs.");
                }
            }

            //Add Administrator claim type to the admin user if not has claim
            var admincp = await signInManager.ClaimsFactory.CreateAsync(adminUser);
            if (!admincp.HasClaim(c => c.Type == AdministratorClaimType))
            {
                var result = await userManager.AddClaimAsync(adminUser, new Claim(AdministratorClaimType, string.Empty));
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException($"Unexpected error occurred adding admin claim to user in Startup.cs.");
                }
            }
        }
    }
}

