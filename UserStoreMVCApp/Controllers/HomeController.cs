using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserStoreMVCApp.Filters;

namespace UserStoreMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private UserStoreDbContext userStoreDbContext { get; set; }

        public HomeController()
        {
            userStoreDbContext = new UserStoreDbContext();
        }

        [CustomAuthenticationFilter]
        // GET: Home
        public ActionResult Index()
        {
            var products = userStoreDbContext.Products.ToList();
            return View(products);
        }
    }
}