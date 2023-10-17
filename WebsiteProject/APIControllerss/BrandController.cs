using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebsiteProject.Models;

namespace WebsiteProject.APIControllerss
{
    public class BrandController : ApiController
    {
        public List<Brand> GET()
        {
            PhoneDbContext db = new PhoneDbContext();
            List<Brand> brands = db.Brands.ToList();
            return brands;
        }
        public Brand GetBrandByBrandId(long id)
        {
            PhoneDbContext db = new PhoneDbContext();
            Brand exitingBrand = db.Brands.Where(t => t.BrandId == id).FirstOrDefault();
            return exitingBrand;
        }
    }
}
