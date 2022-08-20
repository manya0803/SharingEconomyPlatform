using Microsoft.AspNetCore.Mvc;
using SharingEconomyPlatformProject.Models;

namespace SharingEconomyPlatformProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(AdminLogin lg)
        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                var Admin = db.AdminM.Where(x => x.AdminId == lg.AdminId && x.Password == lg.Password);
                if (Admin.Count() > 0)
                {
                    var admin = Admin.FirstOrDefault();
                    
                    
                    return RedirectToAction("AdminPage", "AdminPage");
                }
                else
                {
                    TempData["status"] = "0";
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }

        public IActionResult CustomerDetails()
        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                TempData["CustomerM"] = db.CustomerM.ToList();
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditCustomer(string customerid)
        {
            Customer pp = new Customer();
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                pp = db.CustomerM.Where(x => x.CustomerId == customerid).FirstOrDefault();
            }
            return View(pp);
        }
        [HttpPost]
        public IActionResult EditCustomer(Customer ps)
        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                var result = db.CustomerM.Find(ps.CustomerId);
                result.Id = ps.Id;
                result.FirstName = ps.FirstName;
                result.LastName = ps.LastName;
                result.DOB = ps.DOB;
                result.Gender = ps.Gender;
                result.ContactNumber=ps.ContactNumber;
                result.Address = ps.Address;
                result.City = ps.City;
                result.State = ps.State;
                result.zip = ps.zip;
                result.Email = ps.Email;
                result.Category = ps.Category;
                result.CustomerId = ps.CustomerId;
                result.Password = ps.Password;
                result.ConfirmPassword=ps.ConfirmPassword;
               
                db.SaveChanges();
               
            }
            return View();
        }
        public IActionResult DeleteCustomer(string customerid)
        {
            Customer pp = new Customer();
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                pp = db.CustomerM.Where(x => x.CustomerId == customerid).FirstOrDefault();
                db.CustomerM.Remove(pp);
                db.SaveChanges();

            }
            return View();
        }

        public IActionResult ViewCustomerDetails()
        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                TempData["CustomerM"] = db.CustomerM.ToList();
            }
            return View();
        }

        public IActionResult VendorDetails()
        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                TempData["vendorM"] = db.VendorM.ToList();
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditVendor(string vendorid)
        {
            Vendor pp = new Vendor();
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                pp = db.VendorM.Where(x => x.VendorId == vendorid).FirstOrDefault();
            }
            return View(pp);
        }
        [HttpPost]
        public IActionResult EditVendorr(Vendor ps)
        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                var result = db.VendorM.Find(ps.VendorId);
                result.Id = ps.Id;
                result.FirstName = ps.FirstName;
                result.LastName = ps.LastName;
                result.DOB = ps.DOB;
                result.Gender = ps.Gender;
                result.ContactNumber = ps.ContactNumber;
                result.Address = ps.Address;
                result.City = ps.City;
                result.State = ps.State;
                result.zip = ps.zip;
                result.Email = ps.Email;
                result.Category = ps.Category;
                result.VendorId = ps.VendorId;
                result.Password = ps.Password;
                result.ConfirmPassword = ps.ConfirmPassword;

                db.SaveChanges();

            }
            return View();
        }
        public IActionResult DeleteVendor(string vendorid)
        {
            Vendor pp = new Vendor();
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                pp = db.VendorM.Where(x => x.VendorId == vendorid).FirstOrDefault();
                db.VendorM.Remove(pp);
                db.SaveChanges();

            }
            return View();
        }

        public IActionResult ViewVendorDetails()
        {
            using (SEPGroup2Context db = new SEPGroup2Context())
            {
                TempData["VendorM"] = db.VendorM.ToList();
            }
            return View();
        }



    }
}
