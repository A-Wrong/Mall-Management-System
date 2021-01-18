using Shopping_Mall_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping_Mall_Management.Controllers
{
    public class AdminController : Controller
    {
        MallContext context = new MallContext();
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(Admin admin)
        {
            if (ModelState.IsValid)
            {
                var searchAdmin = context.Admins.Where(x => x.userid.Equals(admin.userid) && x.password.Equals(admin.password)).FirstOrDefault();

                if (searchAdmin != null)
                {
                    //present.UserName = admin.UserName;
                    //TempData["username"] = "Welcome " + searchAdmin.UserName;
                    //TempData.Keep();
                    return RedirectToAction("AdminHome");
                }
                else
                {
                    ViewBag.Message = "Login Fail";
                }
            }
            return View(admin);
        }
        public ActionResult AddStore()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStore(Store s)
        { 
            return View();
        }
        public ActionResult UpdateStore()
        {
            return View();
        }
    }
}