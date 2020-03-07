using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blog_Test.Models;
using Blog_Test.ViewModels;
using Blog_Test.Services;

namespace Blog_Test.Controllers
{
    public class HomeController : Controller
    {
        private IArticleData _articleData;
        private IPreview _previewContent;

        public HomeController(IArticleData articleData, IPreview preview)
        {
            _articleData = articleData;
            _previewContent = preview;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new IndexViewModel();
            model.Articles = _articleData.GetArticles();
            model.Preview = _previewContent.PreviewArticleContent(_articleData.GetArticles()).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _articleData.GetArticle(id);

            return View(model);
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
           
            return RedirectToAction(nameof(Index));
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

                updatedAricle = _articleData.EdditArticle(updatedAricle);
                
                return RedirectToAction(nameof(Details), new { id = updatedAricle.Id });
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
        public IActionResult Create(ArticleEdditData model)
        {
            if (ModelState.IsValid)
            {
                var newArticle = new Article();
                newArticle.Title = model.Title;
                newArticle.Author = model.Author;
                newArticle.Category = model.Category;
                newArticle.Content = model.Content;

                newArticle = _articleData.PostArticle(newArticle);

                return RedirectToAction(nameof(Details), new { id = newArticle.Id });
            }
            else
            {
                return View();
            }
        }
    }
}
