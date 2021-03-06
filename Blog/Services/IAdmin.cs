﻿using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{
    public interface IAdmin
    {
        List<ApplicationUser> GetUsers();
        ApplicationUser DelteUser(string id);
        ApplicationUser UserDetails(string id);
    }
}
