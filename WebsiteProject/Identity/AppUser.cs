using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteProject.Identity
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; }
        public string Address { get; set; }
    }
}