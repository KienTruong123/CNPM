using RiceAgentWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RiceAgentWebsite.Controllers
{
    public class HomeController : Controller
    {
        private RAMS_DBSEntities db = new RAMS_DBSEntities();

      
        public ActionResult Index(string search, string category)
        {
            
            if (category == null)
                ViewData["PRODUCTs"] = db.PRODUCT.Where(x => x.PRODUCT_NAME.Contains(search) || search == null).ToList();
            else
                ViewData["PRODUCTs"] = db.PRODUCT.Where(x => x.PRODUCT_NAME.Contains(category)).ToList();

            return View();
        }
        public ActionResult CategorySearch()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MyCart(string username)
        {
            
            return View(db.CART.Where(x => x.USERNAME.Contains(username)).Include(c => c.PRODUCT).ToList());
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ACCOUNT objUser)
        {
            if (ModelState.IsValid)
            { 
                var obj = db.ACCOUNT.Where(a => a.USERNAME.Equals(objUser.USERNAME) && a.PASSWORD.Equals(objUser.PASSWORD)).FirstOrDefault();
                if (obj != null)
                {
                    Session["UserName"] = obj.USERNAME.ToString();
                    return RedirectToAction("Index");
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}