using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services;
using Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private IArticleData _articleData;
        private ICommentData _commentData;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        private IHttpContextAccessor _httpContext;

        public AdminController(IArticleData articleData,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContext,
            ICommentData commentData
            )
        {
            _articleData = articleData;
            _roleManager = roleManager;
            _userManager = userManager;
            _httpContext = httpContext;
            _commentData = commentData;
        }

        [HttpGet]
        public IActionResult Eddit(int id)
        {
            var model = _articleData.GetArticle(id);

            return View(model);
        }

        public IActionResult Manage()
        {
            return View();
        }


        //[HttpPost]
        //public async Task<IActionResult> Manage()
        //{
        //    var adminExist = await _roleManager.RoleExistsAsync("Admin")

        //    var result = await _roleManager.CreateAsync(new IdentityRole
        //    {
        //        Name = "Admin"
        //    });
        //    var user = await _userManager.GetUserAsync(this.User);
        //    await _userManager.AddToRoleAsync(user, "Admin");
        //    return this.Json(result);
        //}



    }
}