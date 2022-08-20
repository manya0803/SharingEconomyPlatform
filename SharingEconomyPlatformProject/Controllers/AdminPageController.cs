using Microsoft.AspNetCore.Mvc;

namespace SharingEconomyPlatformProject.Controllers
{
    public class AdminPageController : Controller
    {
        public IActionResult AdminPage()
        {
            return View();
        }
        public IActionResult AllServices()
        {
            return RedirectToAction("Index", "Services");
        }
        public IActionResult AllProducts()
        {
            return RedirectToAction("Index", "Products");
        }
    }
}
