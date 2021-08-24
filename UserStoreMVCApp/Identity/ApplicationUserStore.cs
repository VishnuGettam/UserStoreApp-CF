using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserStoreMVCApp.Identity
{
    public class ApplicationUserStore : UserStore<IdentityUser>
    {
        public ApplicationUserStore(ApplicationIdentityDbContext applicationIdentityDbContext) : base(applicationIdentityDbContext)
        {
        }
    }
}