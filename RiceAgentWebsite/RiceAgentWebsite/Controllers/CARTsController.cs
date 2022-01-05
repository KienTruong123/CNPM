using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RiceAgentWebsite.Models;

namespace RiceAgentWebsite.Controllers
{
    public class CARTsController : Controller
    {
        private RAMS_DBSEntities db = new RAMS_DBSEntities();

        // GET: CARTs
        public ActionResult Index()
        {
            var cART = db.CART.Include(c => c.ACCOUNT).Include(c => c.PRODUCT);
            return View(cART.ToList());
        }

        // GET: CARTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CART cART = db.CART.Find(id);
            if (cART == null)
            {
                return HttpNotFound();
            }
            return View(cART);
        }

        // GET: CARTs/Create
        public ActionResult Create()
        {
            ViewBag.USERNAME = new SelectList(db.ACCOUNT, "USERNAME", "USERNAME");
            ViewBag.PRODUCTID = new SelectList(db.PRODUCT, "PRODUCTID", "PRODUCT_NAME");
            return View();
        }

        // POST: CARTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "USERNAME,PRODUCTID,QUANTITY")] CART cART)
        {
            if (ModelState.IsValid)
            {
                var isAlreadyExists = db.CART.Any(x => x.USERNAME == cART.USERNAME && x.PRODUCTID==cART.PRODUCTID);
                if (isAlreadyExists) 
                {
                    return Edit(cART);
                }
                db.CART.Add(cART);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.USERNAME = new SelectList(db.ACCOUNT, "USERNAME", "USERNAME", cART.USERNAME);
            ViewBag.PRODUCTID = new SelectList(db.PRODUCT, "PRODUCTID", "PRODUCT_NAME", cART.PRODUCTID);
            return View(cART);
        }


        // GET: CARTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CART cART = db.CART.Find(id);
            if (cART == null)
            {
                return HttpNotFound();
            }
            ViewBag.USERNAME = new SelectList(db.ACCOUNT, "USERNAME", "USERNAME", cART.USERNAME);
            ViewBag.PRODUCTID = new SelectList(db.PRODUCT, "PRODUCTID", "PRODUCT_NAME", cART.PRODUCTID);
            return View(cART);
        }

        // POST: CARTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "USERNAME,PRODUCTID,QUANTITY")] CART cART)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cART).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USERNAME = new SelectList(db.ACCOUNT, "USERNAME", "USERNAME", cART.USERNAME);
            ViewBag.PRODUCTID = new SelectList(db.PRODUCT, "PRODUCTID", "PRODUCT_NAME", cART.PRODUCTID);
            return View(cART);
        }

        // GET: CARTs/Delete/5
        public ActionResult Delete(string username, int productId)
        {
            if (username == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CART cART = db.CART
            .Where(i => i.PRODUCTID == productId && i.USERNAME == username)
            .Single();
            if (cART == null)
            {
                return HttpNotFound();
            }
            return View(cART);
        }

        // POST: CARTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string username, int productId)
        {
            CART cart = db.CART
             .Where(i => i.PRODUCTID == productId && i.USERNAME==username)
             .Single();
            db.CART.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
