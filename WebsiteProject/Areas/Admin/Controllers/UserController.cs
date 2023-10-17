using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteProject.Identity;
namespace WebsiteProject.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            AppDbContext db = new AppDbContext();
            List<AppUser> users = db.Users.ToList();
            return View(users);
        }
    }
}