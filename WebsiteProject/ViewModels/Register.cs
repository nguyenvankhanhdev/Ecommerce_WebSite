using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteProject.ViewModels
{
    public class Register
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}