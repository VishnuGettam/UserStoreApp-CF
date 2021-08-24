using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserStoreMVCApp.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private UserStoreDbContext userStoreDbContext { get; set; }

        public CategoryController()
        {
            userStoreDbContext = new UserStoreDbContext();
        }

        // GET: Admin/Category
        public ActionResult Index()
        {
            var categories = userStoreDbContext.Categories.ToList();
            return View(categories);
        }
    }
}