using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebsiteProject.Identity;
using WebsiteProject.ViewModels;
using WebsiteProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
namespace WebsiteProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register vm)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new AppDbContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);
                var passwdHash = Crypto.HashPassword(vm.Password);
                var user = new AppUser()
                {
                    Email = vm.Email,
                    UserName = vm.UserName,
                    PasswordHash = passwdHash,
                    PhoneNumber = vm.PhoneNumber,
                    Fullname = vm.Fullname,
                    Address = vm.Address
                    
                };
                IdentityResult identityResult = userManager.Create(user);
                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    var authenManager = HttpContext.GetOwinContext()
                        .Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);

                }
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ModelState.AddModelError("New Error ", "Invalid Data");
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login vm)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.Find(vm.UserName, vm.Password);
            if (user != null) {
                var authencationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authencationManager.SignIn(new AuthenticationProperties(), userIdentity);
                if (userManager.IsInRole(user.Id,"Admin"))
                {
                    return RedirectToAction("Index", "Products", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("Myerror", "Invalid username or password");
                return View();
            }
        }
        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}