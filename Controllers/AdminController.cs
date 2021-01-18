using Shopping_Mall_Management.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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
        //[ValidateAntiForgeryToken]
        public ActionResult LogIn(Admin admin)
        {
            if (ModelState.IsValid)
            {
                var searchAdmin = context.Admins.Where(x => x.Userid.Equals(admin.Userid) && x.Password.Equals(admin.Password)).FirstOrDefault();

                if (searchAdmin != null)
                {
                    //present.UserName = admin.UserName;
                    //TempData["username"] = "Welcome " + searchAdmin.UserName;
                    //TempData.Keep();
                    Session["UserId"] = searchAdmin.Userid.ToString();
                    return RedirectToAction("AdminHome");
                }
                else
                {
                    ViewBag.Message = "Incorrect UserId or Password";
                }
            }
            return View(admin);
        }
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult AddStore()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStore(Store s)
        {
            if (ModelState.IsValid)
            {
                MallContext context = new MallContext();
                context.Stores.Add(s);
                context.SaveChanges();
                ViewBag.Message = "Store details added successfully";
                return View("Dispaly");
            }

            return View();
        }
        public ActionResult UpdateStore()
        {
            List<Store> list = context.Stores.ToList();
            return View(list);
        }
        public ActionResult Details(String id)
        {
            MallContext context = new MallContext();
            var StoreDetails = context.Stores.Find(id);
            return View(StoreDetails);
        }
        public ActionResult Edit(String id)
        {
            MallContext context = new MallContext();
            var StoreDetails = context.Stores.Find(id);
            return View(StoreDetails);

        }
        [HttpPost]
        public ActionResult Edit(Store model)
        {
            MallContext context = new MallContext();
            var StoreDetails = context.Stores.Find(model.Storenumber);
            StoreDetails.Amount = model.Amount;
            StoreDetails.BusinessCategory = model.BusinessCategory;
            StoreDetails.OccupencyStatus = model.OccupencyStatus;
            StoreDetails.StoreArea = model.StoreArea;
            StoreDetails.Storelocation = model.Storelocation;
            StoreDetails.StoreName = model.StoreName;
            StoreDetails.Storesize = model.Storesize;
            StoreDetails.Tenure = model.Tenure;
            context.SaveChanges();

            return RedirectToAction("UpdateStore");

        }
        [HttpPost]
        public ActionResult LogOut()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index","Home");
        }
        public ActionResult RequestApproval()
        {
            List<RentOrLeaseRequest> list = context.RentOrLeaseRequests.ToList();
            return View(list);
        }
        public ActionResult RequestDetails(int id)
        {
            MallContext context = new MallContext();
            var StoreDetails = context.Stores.Find(id);
            return View(StoreDetails);
        }
        public new ActionResult Profile(string name)
        {
            var profile = context.RentOrLeaseRequests.Find(name);
            return View(profile);

        }
        
        public ActionResult Approved(int id)
        {
            string connectionstring = "Data Source=SHAURYA\\SQLEXPRESS;Initial Catalog=MallManagementSystem;User ID=sa;Password=12345678";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string sql = "UPDATE RentOrLeaseRequests SET Status='Approved' WHERE RequestId=@id";
            SqlCommand myCommand = new SqlCommand(sql, conn);
            myCommand.Parameters.AddWithValue("@id", id);
           
                
                myCommand.ExecuteNonQuery();
                conn.Close();
                return RedirectToAction("AdminHome");
            
        }
        
        public ActionResult Rejected(int id)
        {
            string connectionstring = "Data Source=SHAURYA\\SQLEXPRESS;Initial Catalog=MallManagementSystem;User ID=sa;Password=12345678";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string sql = "UPDATE RentOrLeaseRequests SET Status='Rejected' WHERE RequestId=@id";
            SqlCommand myCommand = new SqlCommand(sql, conn);
            myCommand.Parameters.AddWithValue("@id", id);


            myCommand.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("AdminHome");
        }
    }
}
