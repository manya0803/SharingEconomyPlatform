using Microsoft.AspNetCore.Mvc;

namespace SharingEconomyPlatformProject.Controllers
{
    public class CustomerPageController : Controller
    {
        public IActionResult CustomerPage()
        {
            return View();
        }
    }
}
