using AgendaDotNet6MVC.Context;
using AgendaDotNet6MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgendaDotNet6MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

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