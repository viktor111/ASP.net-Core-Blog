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
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Blog.Data;
using ReflectionIT.Mvc.Paging;

namespace Blog.Controllers
{
        
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IArticleData _articleData;
        private IPreview _previewContent;
        private ICommentData _commentData;
        private UserManager<ApplicationUser> _user;
        private RoleManager<IdentityRole> _role;
        private IHttpContextAccessor _httpContext;
        private BlogDbContext _DbContext;

        public HomeController(IArticleData articleData,
            IPreview preview,
            ILogger<HomeController> logger,
            ICommentData comment,
            UserManager<ApplicationUser> user,
            IHttpContextAccessor context,
            RoleManager<IdentityRole> role,
            BlogDbContext DbContext
            )
        {
            _articleData = articleData;
            _previewContent = preview;
            _logger = logger;
            _commentData = comment;
            _user = user;
            _httpContext = context;
            _role = role;
            _DbContext = DbContext;
        }
            
        [HttpGet]
        public IActionResult Details(int id)
        {
            var article = _articleData.GetArticle(id);
           //var comments = _commentData.GetComments(id).ToList();

           //var pagedList =  PagingList.Create(comments, 2, page);

            var model = new ArticeViewModel();
            model.Id = id;
            model.Title = article.Title;
            model.Author = article.Author;
            model.Category = article.Category;
            model.Comments = _commentData.GetComments(id).ToList();
            model.Date = article.Date;
            model.Content = article.Content;
            ViewData["Id"] = model.Id.ToString();

          

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteComment (int id)
        {
            _commentData.DeleteComment(id);
            return RedirectToAction(nameof(Index), "Home");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteArticle(int id)
        {
            _articleData.DeleteArticle(id);
            return RedirectToAction(nameof(Index), "Home");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Eddit(int id)
        {
            var model = _articleData.GetArticle(id);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Article model)
        {
            if (ModelState.IsValid)
            {
                var newArticle = new Article();
                newArticle.Title = model.Title;
                newArticle.Author = model.Author;
                newArticle.Category = model.Category;
                newArticle.Content = model.Content;
                newArticle.Date = DateTime.Now;

                _articleData.PostArticle(newArticle);

                return RedirectToAction("Details", "Home", new { id = newArticle.Id });
            }
            else
            {
                return View();
            }
        }
  
        [Authorize(Policy = "NotBanned")]
        [HttpPost]
        public IActionResult Details(ArticeViewModel comment)
        {
            var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var articleId = HttpContext.Request.Query["id"].ToString();

            var commentToPost = new Comment();
            commentToPost.ArticleId = comment.Id;
            commentToPost.ApplicationUserId = userId;
            commentToPost.Date = DateTime.Now;
            commentToPost.Content = comment.CommentContent;
            if (String.IsNullOrEmpty(commentToPost.Content))
            {
                return RedirectToAction(nameof(Details));
            }
            else
            {
                _commentData.PostComment(commentToPost);
                return RedirectToAction(nameof(Details));
            }            
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index(int page)
        {
            var querry = _httpContext.HttpContext.Request.Headers.FirstOrDefault(r => r.Key.Contains("Referer"));

            var model = new IndexViewModel();
            model.Articles = PagingList.Create(_articleData.GetArticles(), 10, page);

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
