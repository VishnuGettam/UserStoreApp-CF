using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using UserStoreMVCApp.Identity;

namespace UserStoreMVCApp.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationIdentityDbContext applicationIdentityDbContext { get; set; }

        public AccountController()
        {
            applicationIdentityDbContext = new ApplicationIdentityDbContext();
        }

        // GET: Account
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(IdentityUser identityUser, string Password)
        {
            if (ModelState.IsValid)
            {
                string pwdHash = Crypto.HashPassword(Password);
                var user = new IdentityUser()
                {
                    UserName = identityUser.UserName,
                    PhoneNumber = identityUser.PhoneNumber,
                    Email = identityUser.Email,
                    PasswordHash = pwdHash
                };

                var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(applicationIdentityDbContext));
                var result = userManager.Create(user);

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");

                    return RedirectToAction("Login", "Account");
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            if (ModelState.IsValid)
            {
                var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(applicationIdentityDbContext));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(applicationIdentityDbContext));
                var user = userManager.Find(UserName, Password);

                if (user != null)
                {
                    var auth = HttpContext.GetOwinContext();
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    auth.Authentication.SignIn(userIdentity);

                    if (roleManager.FindByName(user.UserName).Name == "Admin")
                    {
                        return RedirectToAction("Index", "Product", new { area = "Admin" });
                    }
                    else if (roleManager.FindByName(user.UserName).Name == "Manager")
                    {
                        return RedirectToAction("Index", "Product", new { area = "Manager" });
                    }
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        public ActionResult LogOut()
        {
            var auth = HttpContext.GetOwinContext();
            auth.Authentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}