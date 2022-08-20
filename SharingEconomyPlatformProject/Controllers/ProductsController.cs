﻿using Microsoft.AspNetCore.Mvc;
using SharingEconomyPlatformProject.Models;

namespace SharingEconomyPlatformProject.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                TempData["products"] = db.products.ToList();
            }
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Products p)
        {
            if (ModelState.IsValid)
            {
                using (SEPGroup2Context db = new SEPGroup2Context())
                {
                    db.products.Add(p);
                    int count = db.SaveChanges();
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
            return View();
        }
        public IActionResult Edit(int id)
        {
            Products pp = new Products();
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                pp = db.products.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(pp);
        }
        [HttpPost]
        public IActionResult Edit(Products ps)
        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                var result = db.products.Find(ps.Id);
                result.ProductName = ps.ProductName;
                result.Quantity = ps.Quantity;
                result.Price = ps.Price;
                db.SaveChanges();
                ModelState.Clear();

            }
            return RedirectToAction("Index", "Products");
        }
        public IActionResult Delete(int id)
        {
            Products pp = new Products();
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                pp = db.products.Where(x => x.Id == id).FirstOrDefault();
                db.products.Remove(pp);
                db.SaveChanges();  
            }
            return RedirectToAction("Index","Products");
        }
        public IActionResult Details()
        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                TempData["products"] = db.products.ToList();
            }
            return View();
        }
    }
}
