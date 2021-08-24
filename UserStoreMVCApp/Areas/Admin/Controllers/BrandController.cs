using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserStoreMVCApp.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        private UserStoreDbContext userStoreDbContext { get; set; }

        public BrandController()
        {
            userStoreDbContext = new UserStoreDbContext();
        }

        // GET: Admin/Brand
        public ActionResult Index()
        {
            var brands = userStoreDbContext.Brands.ToList();
            return View(brands);
        }
    }
}