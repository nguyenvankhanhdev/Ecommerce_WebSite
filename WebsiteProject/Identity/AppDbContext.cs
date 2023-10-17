using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebsiteProject.Identity
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext() : base("MyconnectionString")
        {

        }
        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
        public DbSet<AppUser> Users { get; set; }
    }
}