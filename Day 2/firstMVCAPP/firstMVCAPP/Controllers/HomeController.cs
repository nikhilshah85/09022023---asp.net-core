using firstMVCAPP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace firstMVCAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            //collect data from Model
            //or
            //pass data to model
            return View();
        }

        public IActionResult ContactUs()
        {
            ViewBag.email = "nikhil@gmail.com";
            ViewBag.phone = 30454;
            ViewBag.isActive = true;
            List<string> techList = new List<string>()
            {
                ".Net","Angular","Azure","React","WebAPI","Devops","AI"
            };

            ViewBag.techlist = techList;

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}