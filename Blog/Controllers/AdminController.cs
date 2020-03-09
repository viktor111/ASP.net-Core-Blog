using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services;
using Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IArticleData _articleData;

        public AdminController(IArticleData articleData)
        {
            _articleData = articleData;
        }

        [HttpGet]
        public IActionResult Eddit(int id)
        {
            var model = _articleData.GetArticle(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            _articleData.DeleteArticle(id);

            return RedirectToAction(nameof(Index), "Home");
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
        public IActionResult Create(ArticeViewModel model)
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

                return RedirectToAction("Details","Home", new { id = newArticle.Id });
            }
            else
            {
                return View();
            }
        }
    }
}