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
using Microsoft.AspNetCore.Identity;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IArticleData _articleData;
        private IPreview _previewContent;
        private ICommentData _comment;
        private UserManager<ApplicationUser> _user;

        public HomeController(IArticleData articleData,
            IPreview preview,
            ILogger<HomeController> logger,
            ICommentData comment,
            UserManager<ApplicationUser> user)
        {
            _articleData = articleData;
            _previewContent = preview;
            _logger = logger;
            _comment = comment;
            _user = user;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var article = _articleData.GetArticle(id);

            var model = new ArticeViewModel();
            model.Id = article.Id;
            model.Title = article.Title;
            model.Author = article.Author;
            model.Category = article.Category;
            model.Comments = article.Comments;
            model.Date = article.Date;
            model.Content = article.Content;

            ViewData["Id"] = model.Id.ToString();

            return View(model);
        }



        //[HttpPost]
        //public IActionResult Comment(Comment comment)
        //{

        //    var newComment = new Comment();
        //    newComment.ArticleId = (int)ViewData["Id"];
        //    newComment.ApplicationUserId = User.Identity.Name;
        //    newComment.Date = DateTime.Now;
        //    newComment.Content = comment.Content;

        //    return RedirectToAction(nameof(Index));
        //}

        [HttpGet]
        public IActionResult Index()
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
