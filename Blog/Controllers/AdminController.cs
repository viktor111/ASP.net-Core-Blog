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

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var querry =_httpContext.HttpContext.Request.Headers.FirstOrDefault(r => r.Key.Contains("Referer"));

            if (querry.Value[0].Contains("details"))
            {
                _commentData.DeleteComment(id);
                return RedirectToAction(nameof(Index), "Home");
            }
            else
            {
                _articleData.DeleteArticle(id);
                return RedirectToAction(nameof(Index), "Home");
            }   
        }

        [HttpPost]
        public IActionResult Eddit(Article model)
        {
            if (ModelState.IsValid)
            {
                var updatedAricle = new Article();
                updatedAricle.Id = model.Id;
                updatedAricle.Title = model.Title;
                updatedAricle.Author = model.Author;
                updatedAricle.Category = model.Category;
                updatedAricle.Content = model.Content;
                updatedAricle.Date = DateTime.Now;

                updatedAricle = _articleData.EdditArticle(updatedAricle);

                return RedirectToAction("Details", "Home", new { id = updatedAricle.Id });
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newArticle = new Article();
                newArticle.Title = model.Title;
                newArticle.Author = model.Author;
                newArticle.Category = model.Category;
                newArticle.Content = model.Content;
                newArticle.Date = DateTime.Now;

                newArticle = _articleData.PostArticle(newArticle);

                return RedirectToAction("Details", "Home", new { id = newArticle.Id });
            }
            else
            {
                return View();
            }
        }
    }
}