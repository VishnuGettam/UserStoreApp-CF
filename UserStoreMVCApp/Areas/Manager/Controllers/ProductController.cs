using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserStoreMVCApp.Areas.Manager.Controllers
{
    public class ProductController : Controller
    {
        private UserStoreDbContext userStoreDbContext { get; set; }

        public ProductController()
        {
            userStoreDbContext = new UserStoreDbContext();
        }

        // GET: Manager/Product
        public ActionResult Index()
        {
            var products = userStoreDbContext.Products.ToList();
            return View(products);
        }
    }
}