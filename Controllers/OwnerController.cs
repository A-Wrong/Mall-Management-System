using Microsoft.Ajax.Utilities;
using Shopping_Mall_Management.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping_Mall_Management.Controllers
{
    public class OwnerController : Controller
    {
        MallContext context = new MallContext();
        public ActionResult Register()
        {
            ShopOwner owner = new ShopOwner();
            //return View("Register", owner);
            return View(owner);
        }
        // GET: Owner
        [HttpPost]
        public ActionResult Register(ShopOwner s)
        {
            if (ModelState.IsValid)
            {
                
                context.ShopOwners.Add(s);
                context.SaveChanges();
                ViewBag.Message = "New user created successfully";
                return View("Display");
            }

                return View();
        }
        public ActionResult Login()
        {
            ShopOwner owner = new ShopOwner();
            return View(owner);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(ShopOwner owner)
        {
             
                    var searchUser = context.ShopOwners.Where(x => x.Userid.Equals(owner.Userid) && x.Password.Equals(owner.Password)).FirstOrDefault();
                    
                    if (searchUser != null)
                    {
                        Session["UserId"] = searchUser.Userid.ToString();
                        return RedirectToAction("OwnerHome");
                    }
                    else
                    {
                        ViewBag.Message = "Incorrect UserId or Password";
                        
                    }

            return View();
        }
        public ActionResult OwnerHome()
        {
            return View();
        }
        public ActionResult Profiles()
        {
            String OwnerId = Session["OwnerId"].ToString();
            List<ShopOwner> list = context.ShopOwners.ToList();
            ShopOwner obj = list.Where(x=>x.Userid== OwnerId).FirstOrDefault();

            return View(obj);
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            return View();
        }
        
        public ActionResult RaiseRequest()
        {
            String Userid = Session["UserId"].ToString();
            String name = context.ShopOwners.Where(x => x.Userid == Userid).FirstOrDefault().FirstName;
            RentOrLeaseRequest rol = context.RentOrLeaseRequests.Where(x => x.StoreOwnerName == name).FirstOrDefault();
            if (rol == null)
            {
                List<Store> stores = context.Stores.Where(x => x.OccupencyStatus=="Vacant").ToList();
                rol = new RentOrLeaseRequest();
                rol.Status = "New";
                List<ShopOwner> shopOwners = context.ShopOwners.ToList();
                List<BussinessProfile> profiles = context.BussinessProfiles.ToList();
                ArrayList arl = new ArrayList();
                arl.Add(rol);
                arl.Add(stores);
                arl.Add(shopOwners);
                arl.Add(profiles);
                return View(arl);

            }
            else
            {
                if (rol.Status == "Pending")
                {
                    ViewBag.Message = "The request was already raised, awaiting approval";
                }
                else if (rol.Status == "Approved")
                {
                    ViewBag.Message = "The current request is already approved";
                }
                else
                {
                    ViewBag.Message = "The request was rejected by admin";

                }
                return View("Success");

            }

        }
        public ActionResult RequestRaised(int id)
        {
            List<RentOrLeaseRequest> rols = (List<RentOrLeaseRequest>)Session["ROLS"];
            RentOrLeaseRequest obj = rols[id];
            obj.Status = "Pending";
            context.RentOrLeaseRequests.Add(obj);
            context.SaveChanges();
            return RedirectToAction("RaiseRequest");
        }
    public ActionResult ViewShopDetails()
        {
            List<Store> list = context.Stores.ToList();
            return View(list);
        }
        public ActionResult Details(string id)
        {
            
            var StoreDetails = context.Stores.Find(id);
            return View(StoreDetails);
            
        }
        public ActionResult EditShopOwnerProfile()
        {
            ViewBag.Flag = "Old";
            String userId = Session["UserId"].ToString();
            ShopOwner owner = context.ShopOwners.Find(userId);
            BussinessProfile bp = context.BussinessProfiles.Find(userId);
            if (bp == null)
            {
                bp = new BussinessProfile();
                bp.BussinessProfileId = userId;
                ViewBag.Flag = "New";
            }
            ArrayList arl = new ArrayList();
            arl.Add(owner);
           
            arl.Add(bp);
            return View(arl);
        }
        [HttpPost]
        public ActionResult EditShopOwnerProfile(FormCollection frm)
        {
            String userId = Session["OwnerId"].ToString();
            ShopOwner owner = context.ShopOwners.Find(userId);
            BussinessProfile bp = new BussinessProfile();
            owner.FirstName = frm["t2"];
            owner.ContactNumber = frm["t3"];
            owner.Email = frm["t4"];
            context.SaveChanges();
            bp.BussinessProfileId = frm["t1"];
            bp.ShopName = frm["t5"];
            bp.BusinessCategory = frm["t6"];
            bp.TotalEmployees = Int32.Parse(frm["t7"]);
            bp.Workinghours = Int32.Parse(frm["t8"]);
            bp.Holiday = frm["t9"];
            bp.LicenseNumber = frm["t10"];
            bp.LicenseExpiryDate = DateTime.Parse(frm["t11"]);
            context.BussinessProfiles.Add(bp);
            context.SaveChanges();
            ViewBag.Message = "Profile updated successfully";
            return View("Success");


        }
        public ActionResult RequestStatus()
        {
            List<RentOrLeaseRequest> list = context.RentOrLeaseRequests.ToList();
            return View(list);
        }
        public ActionResult RequestDetails(int id)
        {
           
            var StoreDetails = context.Stores.Find(id);
            return View(StoreDetails);
        }
    }
}
