using Microsoft.AspNetCore.Mvc;
using SharingEconomyPlatformProject.Models;

namespace SharingEconomyPlatformProject.Controllers
{
    public class VendorPageController : Controller
    {
        public IActionResult vendorpage()
        {
            return View();
        }
        public IActionResult AllServices()
        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                TempData["services"] = db.services.ToList();
            }
            return RedirectToAction("Index","Services");
        }
        public IActionResult AllProducts()
        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                TempData["productss"] = db.products.ToList();
            }
            return RedirectToAction("Index", "Products");
        }
    }
}
