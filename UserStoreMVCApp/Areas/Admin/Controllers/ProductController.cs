using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserStoreMVCApp.Filters;

namespace UserStoreMVCApp.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]
    [CustomAuthorization]
    public class ProductController : Controller
    {
        private UserStoreDbContext userStoreDbContext { get; set; }

        public ProductController()
        {
            userStoreDbContext = new UserStoreDbContext();
        }

        // GET: Admin/Product
        public ActionResult Index()
        {
            var products = userStoreDbContext.Products.ToList();

            return View(products);
        }
    }
}