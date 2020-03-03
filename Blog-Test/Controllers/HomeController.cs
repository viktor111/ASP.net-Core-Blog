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
        private readonly ILogger<HomeController> _logger;
        private IArticleData _articleData;

        public HomeController(ILogger<HomeController> logger, IArticleData articleData)
        {
            _logger = logger;
            _articleData = articleData;
        }
            
        public IActionResult Index()
        {
            var model = new IndexViewModel();
            model.Articles = _articleData.GetArticles();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var model = _articleData.GetArticle(id);

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
