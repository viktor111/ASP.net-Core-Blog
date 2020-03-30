using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class ToolsController : Controller
    {


        public ToolsController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult IpLookUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IpLookUp(ToolsViewModel toolsViewModel)
        {
            ToolsViewModel model = new ToolsViewModel();
            model.Website = toolsViewModel.Website;

            return View(model);
        }
    }
}