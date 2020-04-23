using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ImperiumSite.Models;
using Microsoft.AspNetCore.Authorization;

namespace ImperiumSite.Controllers
{
    public class HomeController : Controller
    {
        //Manager Class Instance 
        public Manager m = new Manager();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Credit()
        {
            return View();
        }

        public IActionResult About()
        {
            return View("AboutGame");
        }

        public IActionResult Developers()
        {
            return View("AboutDev");
        }

        public virtual ActionResult Error(int? statusCode = null)
        {
            if (statusCode.HasValue)
            {
                if (statusCode == 404 || statusCode == 500)
                {
                    var viewName = statusCode.ToString();
                    return View(viewName);
                }
            }
            return View();
        }
    }
}
