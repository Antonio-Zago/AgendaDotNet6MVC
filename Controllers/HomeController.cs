using AgendaDotNet6MVC.Context;
using AgendaDotNet6MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgendaDotNet6MVC.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}