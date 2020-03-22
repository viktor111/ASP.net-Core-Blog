﻿using System;
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

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IArticleData _articleData;
        private IPreview _previewContent;
        private ICommentData _comment;
        private UserManager<ApplicationUser> _user;
       // private RoleManager<IdentityRole> _role;
       private IHttpContextAccessor _context;

        public HomeController(IArticleData articleData,
            IPreview preview,
            ILogger<HomeController> logger,
            ICommentData comment,
            UserManager<ApplicationUser> user,
            IHttpContextAccessor context
            )
        {
            _articleData = articleData;
            _previewContent = preview;
            _logger = logger;
            _comment = comment;
            _user = user;
            _context = context;
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


        [HttpPost]
        public IActionResult Comment(Comment comment)
        {
            var userId = _context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var newComment = new Comment();
            newComment.ApplicationUserId = userId;
            newComment.Date = DateTime.Now;
            newComment.Content = comment.Content;

            _comment.PostComment(newComment);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Index()
        {


            var model = new IndexViewModel();
            model.Articles = _articleData.GetArticles();

            IEnumerable<Article> articles = model.Articles;

            model.Preview = _previewContent.PreviewArticleContent(articles).ToList();        

            return View(model);
        }

        public async Task<IActionResult> UserTestAsync()
        {
            var user = await _user.GetUserAsync(this.User);
            return Json(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
