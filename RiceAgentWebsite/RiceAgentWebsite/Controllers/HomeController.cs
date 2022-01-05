using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RiceAgentWebsite.Controllers
{
    public class HomeController : Controller
    {
        private RAMS_DBSEntities db = new RAMS_DBSEntities();

        // GET: PRODUCTs
        public ActionResult Index(string search, string category)
        {
            if(category == null)
                return View(db.PRODUCT.Where(x => x.PRODUCT_NAME.Contains(search) || search == null).ToList());
            else
                return View(db.PRODUCT.Where(x => x.PRODUCT_NAME.Contains(category)).ToList());
        }


        public ActionResult CategorySearch()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}