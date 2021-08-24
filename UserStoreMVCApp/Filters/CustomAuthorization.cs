using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserStoreMVCApp.Filters
{
    public class CustomAuthorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.IsInRole("Admin"))
            {
                filterContext.Result = new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized, "Please login with 'Admin' Role");
            }
        }
    }
}