using Microsoft.AspNetCore.Mvc;
using SharingEconomyPlatformProject.Models;

namespace SharingEconomyPlatformProject.Controllers
{
    public class BookProductController : Controller
    {
        public IActionResult CustomerIndex()
        {
            {
                using (SEPGroup2Context db = new SEPGroup2Context())
                {
                    TempData["products"] = db.products.ToList();
                }
                return View();
            }
        }
        public IActionResult BookProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BookProduct(BookProduct bp)
        {
            if (ModelState.IsValid)
            {
                using (SEPGroup2Context db = new SEPGroup2Context())
                {
                    db.bookProducts.Add(bp);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("ProductsView","BookProduct");
        }
        public IActionResult ProductsView()

        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                TempData["bookProducts"] = db.bookProducts.ToList();
            }
            return View();
        }
        
        public IActionResult CancelProduct(string productname)
        {
            BookProduct bp = new BookProduct();
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                bp = db.bookProducts.Where(x => x.ProductName == productname).FirstOrDefault();
                db.bookProducts.Remove(bp);
                db.SaveChanges();
            }
             return RedirectToAction("ProductsView","BookProduct");
        }

    }
}
