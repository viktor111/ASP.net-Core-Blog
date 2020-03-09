using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blog.Models;
using Blog.Services;
using Blog.ViewModels;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;       
        private IArticleData _articleData;
        private IPreview _previewContent;

        public HomeController(IArticleData articleData
            , IPreview preview
            , ILogger<HomeController> logger)
        {
            _articleData = articleData;
            _previewContent = preview;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _articleData.GetArticle(id);

            return View(model);
        }

        [HttpGet]
        public IActionResult Index(SortType sort)
        {
            

            var model = new IndexViewModel();
            model.Articles = _articleData.GetArticles();

            IEnumerable<Article> articles = model.Articles;

            model.Preview = _previewContent.PreviewArticleContent(articles).ToList();

            return View(model);
        }
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
