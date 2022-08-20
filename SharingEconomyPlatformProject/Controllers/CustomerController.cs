using Microsoft.AspNetCore.Mvc;
using SharingEconomyPlatformProject.Models;

namespace SharingEconomyPlatformProject.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(CustomerLogin lg)
        {
           
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                var customers = db.CustomerM.Where(x => x.CustomerId == lg.CustomerId && x.Password == lg.Password);
                if (customers.Count() > 0)
                {
                    var customer = customers.FirstOrDefault();
                   // HttpContext.Session.SetString("role", customer.Category);
                    TempData["status"] = "1";

                    return RedirectToAction("CustomerPage", "CustomerPage");
                }
                else
                {
                    TempData["status"] = "0";
                }
            }
            return View();
        }
        public IActionResult CustomerRegistration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CustomerRegistration(Customer rg)
        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                db.CustomerM.Add(rg);
                if (db.SaveChanges() > 0)
                {
                    TempData["status"] = "ok";
                }
                return RedirectToAction("Login", "Customer");

            }
            
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}
