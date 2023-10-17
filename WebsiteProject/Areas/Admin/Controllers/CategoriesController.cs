using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteProject.Models;

namespace WebsiteProject.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Admin/Categories
        public ActionResult Index()
        {
            PhoneDbContext db = new PhoneDbContext();
            List<Category> Category = db.Categories.ToList();
            return View(Category);
        }
    }
}