using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Helpers;
using UserStoreMVCApp.Identity;

[assembly: OwinStartup(typeof(UserStoreMVCApp.Startup))]

namespace UserStoreMVCApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            CreateUserRoles();
        }

        private static void CreateUserRoles()
        {
            var appIdentityDbContext = new ApplicationIdentityDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(appIdentityDbContext));
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(appIdentityDbContext));

            //Create Admin Role
            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole() { Id = "1", Name = "Admin" });
            }

            //Create Admin User
            if (userManager.FindByName("Admin") == null)
            {
                string pwdHash = Crypto.HashPassword("admin123");

                var user = new IdentityUser()
                {
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                    PasswordHash = pwdHash
                };

                var result = userManager.Create(user);

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            //Create Manager Role
            if (!roleManager.RoleExists("Manager"))
            {
                roleManager.Create(new IdentityRole() { Id = "2", Name = "Manager" });
            }

            //Create Admin User
            if (userManager.FindByName("Manager") == null)
            {
                string pwdHash = Crypto.HashPassword("manager123");

                var user = new IdentityUser()
                {
                    UserName = "Manager",
                    Email = "manager@gmail.com",
                    PasswordHash = pwdHash
                };

                var result = userManager.Create(user);

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");
                }
            }

            //Create Customer Role
            if (!roleManager.RoleExists("Customer"))
            {
                roleManager.Create(new IdentityRole() { Id = "3", Name = "Customer" });
            }

            //Create Admin User
            if (userManager.FindByName("Customer") == null)
            {
                string pwdHash = Crypto.HashPassword("customer123");

                var user = new IdentityUser()
                {
                    UserName = "Customer",
                    Email = "customerr@gmail.com",
                    PasswordHash = pwdHash
                };

                var result = userManager.Create(user);

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                }
            }
        }
    }
}