using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Services;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class ToolsController : Controller
    {
        private ITools _tools;

        public ToolsController
            (
             ITools tools
            )
        {
            _tools = tools;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IpLookUp()
        {
            return View();
        }

        public IActionResult IpLookUpPOST(ToolsViewModel toolsViewModel)
        {
            ToolsViewModel model = new ToolsViewModel();
            model.Website = toolsViewModel.Website;
            ViewData["Ip"] =
                _tools.IpLookUp(model.Website);
            return View(model);
        }
    }
}