using Shopping_Mall_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping_Mall_Management.Controllers
{
    public class OwnerController : Controller
    {
        public ActionResult Register()
        {
            //Shop_Owner owner = new Shop_Owner();
            //return View("Register", owner);
            return View();
        }
        // GET: Owner
        [HttpPost]
        public ActionResult Register(Shop_Owner s)
        {
            if (ModelState.IsValid)
            {
                MallContext context = new MallContext();
                context.Shop_Owners.Add(s);
                context.SaveChanges();
                ViewBag.Message = "New user created successfully";
                return RedirectToAction("Login","Owner");
            }

                return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        
    }
}