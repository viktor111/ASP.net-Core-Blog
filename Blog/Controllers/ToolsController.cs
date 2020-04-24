using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Blog.Services;
using Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Authorize(Policy = "NotBanned")]
    public class ToolsController : Controller
    {
        private ITools _tools;
        private HttpClient _client;

        public ToolsController
            (
             ITools tools,
             HttpClient client
            )
        {
            _tools = tools;
            _client = client;
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
            try
            {
                ToolsViewModel model = new ToolsViewModel();
                model.Website = toolsViewModel.Website;
                ViewData["Ip"] = _tools.IpLookUp(model.Website);
                return View(model);
            }
            catch (Exception)
            {
                ViewData["Ip"] = "Input correct url! Only domain.";
                return View();
            }
          
        }

        public IActionResult WhatsMyIp()
        {
            ViewData["MyIp"] = _tools.WhatsMyIp();
            return View();
        }

        public IActionResult PortScan()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> PortScan(ToolsViewModel viewModel)
        {
            var values = new Dictionary<string, string>
            {
              { "target", viewModel.Website },
            };

            var content = new FormUrlEncodedContent(values);
            try
            {
                var response = await _client.PostAsync("http://localhost:3000/api/scan", content);

                // "80|HTTP;443|HTTPS;80|HTTP;"
                var responseString = await response.Content.ReadAsStringAsync();

                var res = responseString.Split(";");
                var model = new ToolsViewModel();
                model.OpenPorts = res;
                ViewData["Prts"] = res;
                return View(model);
            }
            catch (Exception)
            {

                return RedirectToAction(nameof(PortScan));

            }
        }
    }
}
