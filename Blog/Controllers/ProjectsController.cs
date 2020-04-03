using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services;
using Blog.ViewModels;
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
        public IActionResult Delete(int id)
        {
            _project.DeleteProject(id);
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

                model = _project.PostProject(model);
                return RedirectToAction("Details", new { id = model.Id });
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _project.GetProject(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                var model = new Project();
                model.Id = project.Id;
                model.Ttitle = project.Ttitle;
                model.Description = project.Description;
                model.Date = DateTime.Now;
                model.GitHubLink = project.GitHubLink;
                model.Technology = project.Technology;

                model = _project.EdditProject(model);
                return RedirectToAction(nameof(List));
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var project = _project.GetProject(id);

            var model = new ProjectsViewModel();
            model.Ttitle = project.Ttitle;
            model.Description = project.Description;
            model.GitHubLink = project.GitHubLink;
            model.Technology = project.Technology;

            ViewData["Id"] = model.Id.ToString();
            return View(model);
        }

        public IActionResult List()
        {
            var model = new ProjectsViewModel();
            model.Projects = _project.GetProjects();

            return View(model);
        }
    }
}