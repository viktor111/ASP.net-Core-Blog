using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class ProjectsController : Controller
    {
        private IProjectData _project;
        private UserManager<ApplicationUser> _user;
        private RoleManager<IdentityRole> _role;

        public ProjectsController(IArticleData articleData,

            UserManager<ApplicationUser> user,
            RoleManager<IdentityRole> role,
            IProjectData project
            )
        {
            _user = user;
            _role = role;
            _project = project;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                var model = new Project();
                model.Ttitle = project.Ttitle;
                model.Description = project.Description;
                model.Date = DateTime.Now;
                model.GitHubLink = project.GitHubLink;
                model.Technology = project.Technology;

                model = _project.PostArticle(model);
                return RedirectToAction("Details", "Project", new { id = model.Id });
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }
    }
}