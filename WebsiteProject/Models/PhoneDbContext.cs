using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebsiteProject.Models
{
    public class PhoneDbContext:DbContext
    {
        public PhoneDbContext() : base("MyconnectionString")
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet <Product> Products { get; set;}
        public DbSet <User> Users { get; set; }
    }
}