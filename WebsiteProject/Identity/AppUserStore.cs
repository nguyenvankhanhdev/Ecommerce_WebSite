using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteProject.Identity
{
    public class AppUserStore:UserStore<AppUser>
    {
        public AppUserStore(AppDbContext dbContext ):base(dbContext) { }
    }
}