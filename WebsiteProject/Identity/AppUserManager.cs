﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteProject.Identity
{
    public class AppUserManager:UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store):base(store) { }
    }
}