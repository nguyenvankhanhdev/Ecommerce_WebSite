using Microsoft.Owin;
using Owin; // Dòng này để sử dụng phương thức UseSession
using Microsoft.Extensions.DependencyInjection; // Dòng này để sử dụng phương thức AddSession
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;
using WebsiteProject.Identity;
using Microsoft.AspNetCore.Hosting;

using System.Web.Services.Description;
using Microsoft.AspNetCore.Builder;

[assembly: OwinStartup(typeof(WebsiteProject.Startup))]

namespace WebsiteProject
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            this.CreateRolesAndUser();

		}

		public void ConfigureServices(IServiceCollection services)
		{
			// ...
			services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMilliseconds(1); 
			});
		}


		public void Configure(IApplicationBuilder app)
		{
			// ...
			app.UseSession();
		}

		public void CreateRolesAndUser()
        {
            var roleManager = new RoleManager<IdentityRole>(new
                RoleStore<IdentityRole>( new AppDbContext()));
            var appDbContext = new AppDbContext();
            var appUserStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(appUserStore);

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            if (userManager.FindByName("Admin") == null)
            {
                var user = new AppUser();
                user.UserName="Admin";
                user.Email="admin@gmail.com";
                string userPassword = "admin123";
                var checkUser = userManager.Create(user, userPassword);

                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "admin");
                }
            }

            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }
            if (userManager.FindByName("manager") == null)
            {
                var user = new AppUser();
                user.UserName = "manager";
                user.Email = "manager@gmail.com";
                string userPassword = "manager123";
                var checkUser = userManager.Create(user, userPassword);

                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "manager");
                }
            }
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }


        }

    }
}
