using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> _user;

        public UserController(UserManager<ApplicationUser> user)
        {
            _user = user;
        }

    }
}