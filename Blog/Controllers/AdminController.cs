using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Blog.Models;
using Blog.Services;
using Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Blog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private HttpClient _client;
        private IArticleData _articleData;
        private IAdmin _admin;
        private ICommentData _commentData;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        private IHttpContextAccessor _httpContext;

        public AdminController(
            IArticleData articleData,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContext,
            ICommentData commentData,
            IAdmin admin,
            HttpClient client
            )
        {
            _articleData = articleData;
            _roleManager = roleManager;
            _userManager = userManager;
            _httpContext = httpContext;
            _commentData = commentData;
            _admin = admin;
            _client = client;
        }

        public IActionResult DeleteUser(string id)
        {
            _admin.DelteUser(id);
            return RedirectToAction(nameof(Manage));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage()
        {
            var model = new AdminViewModel();
            model.Users = _admin.GetUsers();

            return View(model);
        }

        public async Task<IActionResult> UnRestrictUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var isInUserRole = await _userManager.IsInRoleAsync(user, "Banned");

            if (!isInUserRole)
            {      
                return RedirectToAction(nameof(Manage));
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, "Banned");
                await _userManager.AddToRoleAsync(user, "User");
                ViewBag.Messege = "User banned";
                return RedirectToAction(nameof(Manage));
            }
        }

        [HttpPost]
        public async Task<IActionResult> RestrictUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var isInUserRole = await _userManager.IsInRoleAsync(user, "User");

            if (!isInUserRole)
            {
                ViewBag.Messege = "User already banned";
                return RedirectToAction(nameof(Manage));
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, "User");
                await _userManager.AddToRoleAsync(user, "Banned");
                ViewBag.Messege = "User banned";
                return RedirectToAction(nameof(Manage));
            }
        }

        public IActionResult Details(string id)
        {
            var model = new AdminViewModel();
            model.UserComments = _commentData.GetCommentsForUser(id).ToList();
            model.UserEamil = _admin.UserDetails(id).Email;
            model.Username = _admin.UserDetails(id).UserName;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddRole()
        {
            var result = await _roleManager.CreateAsync(new IdentityRole
            {
                Name = "User"
            });

            return this.Json(result);
        }


    }
}