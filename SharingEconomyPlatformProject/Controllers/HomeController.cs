using Microsoft.AspNetCore.Mvc;
using SharingEconomyPlatformProject.Models;
using System.Diagnostics;

namespace SharingEconomyPlatformProject.Controllers
{
    public class HomeController : Controller
    {
       public IActionResult Home()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}