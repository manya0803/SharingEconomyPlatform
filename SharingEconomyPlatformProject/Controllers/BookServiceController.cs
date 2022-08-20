using Microsoft.AspNetCore.Mvc;
using SharingEconomyPlatformProject.Models;

namespace SharingEconomyPlatformProject.Controllers
{
    public class BookServiceController : Controller
    {
        public IActionResult CustomerIndex()
        {
            {
                using (SEPGroup2Context db = new SEPGroup2Context())
                {
                    TempData["services"] = db.services.ToList();
                }
                return View();
            }
        }
        public IActionResult BookService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BookService(BookService bs)
        {
            if (ModelState.IsValid)
            {
                using (SEPGroup2Context db = new SEPGroup2Context())
                {
                    db.bookServices.Add(bs);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("ServicesView", "BookService");
        }
        public IActionResult ServicesView()

        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                TempData["bookServices"] = db.bookServices.ToList();
            }
            return View();
        }

        public IActionResult CancelService(string Servicename)
        {
            BookService bs = new BookService();
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                bs = db.bookServices.Where(x => x.ServiceName == Servicename).FirstOrDefault();
                db.bookServices.Remove(bs);
                db.SaveChanges();
            }
            return RedirectToAction("ServicesView", "BookService");
        }
        public IActionResult Order()
        {
            return View();
        }

    }
}

    

