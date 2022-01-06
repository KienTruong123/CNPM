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
    public class BILL_PRODUCTSController : Controller
    {
        private RAMS_DBSEntities db = new RAMS_DBSEntities();

        // GET: BILL_PRODUCTS
        public ActionResult Index()
        {
            var bILL_PRODUCTS = db.BILL_PRODUCTS.Include(b => b.BILL).Include(b => b.PRODUCT);
            return View(bILL_PRODUCTS.ToList());
        }

        // GET: BILL_PRODUCTS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BILL_PRODUCTS bILL_PRODUCTS = db.BILL_PRODUCTS.Find(id);
            if (bILL_PRODUCTS == null)
            {
                return HttpNotFound();
            }
            return View(bILL_PRODUCTS);
        }

        // GET: BILL_PRODUCTS/Create
        public ActionResult Create()
        {
            ViewBag.BILLID = new SelectList(db.BILL, "BILLID", "STATUS");
            ViewBag.PRODUCTID = new SelectList(db.PRODUCT, "PRODUCTID", "PRODUCT_NAME");
            return View();
        }

        // POST: BILL_PRODUCTS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BILLID,PRODUCTID,PRICE,QUANTITY")] BILL_PRODUCTS bILL_PRODUCTS)
        {
            if (ModelState.IsValid)
            {
                db.BILL_PRODUCTS.Add(bILL_PRODUCTS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BILLID = new SelectList(db.BILL, "BILLID", "STATUS", bILL_PRODUCTS.BILLID);
            ViewBag.PRODUCTID = new SelectList(db.PRODUCT, "PRODUCTID", "PRODUCT_NAME", bILL_PRODUCTS.PRODUCTID);
            return View(bILL_PRODUCTS);
        }

        // GET: BILL_PRODUCTS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BILL_PRODUCTS bILL_PRODUCTS = db.BILL_PRODUCTS.Find(id);
            if (bILL_PRODUCTS == null)
            {
                return HttpNotFound();
            }
            ViewBag.BILLID = new SelectList(db.BILL, "BILLID", "STATUS", bILL_PRODUCTS.BILLID);
            ViewBag.PRODUCTID = new SelectList(db.PRODUCT, "PRODUCTID", "PRODUCT_NAME", bILL_PRODUCTS.PRODUCTID);
            return View(bILL_PRODUCTS);
        }

        // POST: BILL_PRODUCTS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BILLID,PRODUCTID,PRICE,QUANTITY")] BILL_PRODUCTS bILL_PRODUCTS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bILL_PRODUCTS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BILLID = new SelectList(db.BILL, "BILLID", "STATUS", bILL_PRODUCTS.BILLID);
            ViewBag.PRODUCTID = new SelectList(db.PRODUCT, "PRODUCTID", "PRODUCT_NAME", bILL_PRODUCTS.PRODUCTID);
            return View(bILL_PRODUCTS);
        }

        // GET: BILL_PRODUCTS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BILL_PRODUCTS bILL_PRODUCTS = db.BILL_PRODUCTS.Find(id);
            if (bILL_PRODUCTS == null)
            {
                return HttpNotFound();
            }
            return View(bILL_PRODUCTS);
        }

        // POST: BILL_PRODUCTS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BILL_PRODUCTS bILL_PRODUCTS = db.BILL_PRODUCTS.Find(id);
            db.BILL_PRODUCTS.Remove(bILL_PRODUCTS);
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
