using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Cv()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View();
        }
    }
}