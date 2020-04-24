using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class ErrorController : Controller
    {

        [Route("/PageNotFound")]
        public IActionResult PageNotFound()
        {
            return Json(2);
        }
    }
}