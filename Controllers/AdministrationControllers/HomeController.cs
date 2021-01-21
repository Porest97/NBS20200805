using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NBS.Models;
using NBS.Models.ViewModels;

namespace NBS.Controllers.AdministrationControllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Billing()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Incidents()
        {
            return View();
        }
        public IActionResult Planning()
        {
            return View();
        }

        public IActionResult Reports()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Links()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Settings()
        {
            return View();
        }
        public IActionResult DrawIO()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
