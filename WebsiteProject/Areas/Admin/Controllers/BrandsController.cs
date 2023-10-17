using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebsiteProject.Models;

namespace WebsiteProject.Areas.Admin.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Admin/Brands
        public ActionResult Index(string search = "", int PageNo = 1)
        {
            PhoneDbContext db = new PhoneDbContext();
            ViewBag.Search = search;
            List<Brand> brands = db.Brands.Where(t => t.BrandName.Contains(search)).ToList();

            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(brands.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPage = NoOfPages;
            brands = brands.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            return View(brands);
        }
    }
}