using Microsoft.AspNetCore.Mvc;
using SharingEconomyPlatformProject.Models;

namespace SharingEconomyPlatformProject.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                TempData["services"] = db.services.ToList();
            }
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Services s)
        {
            if (ModelState.IsValid)
            {
                using (SEPGroup2Context db = new SEPGroup2Context())
                {
                    db.services.Add(s);
                    int count=db.SaveChanges();
                    if (count > 0)
                    {
                        TempData["status"] = "1";
                        db.SaveChanges();
                    }
                    else
                    {
                        TempData["status"] = "0";
                    }

                }
            }
            return RedirectToAction("Index","Services");
        }
        public IActionResult Edit(int id)
        {
            Services pp = new Services();
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                pp = db.services.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(pp);
        }
        [HttpPost]
        public IActionResult Edit(Services sp)
        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                var result = db.services.Find(sp.Id);
                result.ServiceName = sp.ServiceName;
                result.Price = sp.Price;
                db.SaveChanges();
                ModelState.Clear();

            }
            return RedirectToAction("Index", "Services");
        }
        public IActionResult Delete(int id)
        {
            Services sp = new Services();
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                sp = db.services.Where(x => x.Id == id).FirstOrDefault();
                db.services.Remove(sp);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Services");
        }

        public IActionResult Details()
        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                TempData["services"] = db.services.ToList();
            }
            return View();
        }
    }
}
