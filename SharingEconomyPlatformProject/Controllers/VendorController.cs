using Microsoft.AspNetCore.Mvc;


using SharingEconomyPlatformProject.Models;

namespace SharingEconomyPlatformProject.Controllers
{
    public class VendorController : Controller
    {
        

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(VendorLogin lg)
        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                var vendors = db.VendorM.Where(x => x.VendorId == lg.VendorId && x.Password == lg.Password);
                if (vendors.Count() > 0)
                {
                    var vendor = vendors.FirstOrDefault();
                    
                    
                    TempData["status"] = "ok";

                    return RedirectToAction("vendorpage", "VendorPage");
                }
                
            }
            return View();
        }
        public IActionResult VendorRegistration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult VendorRegistration(Vendor rg)
        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                db.VendorM.Add(rg);
                if (db.SaveChanges() > 0)
                {
                    TempData["status"] = "ok";
                   
                }
               
            }
            return RedirectToAction("login", "Vendor");
        }

        public IActionResult Logout()
        {
            return View();
        }

    }
}
