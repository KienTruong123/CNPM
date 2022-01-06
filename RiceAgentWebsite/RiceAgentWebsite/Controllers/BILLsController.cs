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
    public class BILLsController : Controller
    {
        private RAMS_DBSEntities db = new RAMS_DBSEntities();

        // GET: BILLs
        public ActionResult Index()
        {
            var bILL = db.BILL.Include(b => b.CUSTOMER).Include(b => b.BILL_TYPE);
            return View(bILL.ToList());
        }

        // GET: BILLs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BILL bILL = db.BILL.Find(id);
            if (bILL == null)
            {
                return HttpNotFound();
            }
            return View(bILL);
        }

        // GET: BILLs/Create
        public ActionResult Create()
        {
            ViewBag.CUSTOMERID = new SelectList(db.CUSTOMER, "CUSTOMERID", "USERNAME");
            ViewBag.TYPEID = new SelectList(db.BILL_TYPE, "TYPEID", "TYPE_NAME");
            return View();
        }

        // POST: BILLs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BILLID,CUSTOMERID,STATUS,DATE_CREATED,DATE_CLOSED,PAYMENT_METHOD,TYPEID")] BILL bILL)
        {
            if (ModelState.IsValid)
            {
                db.BILL.Add(bILL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CUSTOMERID = new SelectList(db.CUSTOMER, "CUSTOMERID", "USERNAME", bILL.CUSTOMERID);
            ViewBag.TYPEID = new SelectList(db.BILL_TYPE, "TYPEID", "TYPE_NAME", bILL.TYPEID);
            return View(bILL);
        }

        // GET: BILLs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BILL bILL = db.BILL.Find(id);
            if (bILL == null)
            {
                return HttpNotFound();
            }
            ViewBag.CUSTOMERID = new SelectList(db.CUSTOMER, "CUSTOMERID", "USERNAME", bILL.CUSTOMERID);
            ViewBag.TYPEID = new SelectList(db.BILL_TYPE, "TYPEID", "TYPE_NAME", bILL.TYPEID);
            return View(bILL);
        }

        // POST: BILLs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BILLID,CUSTOMERID,STATUS,DATE_CREATED,DATE_CLOSED,PAYMENT_METHOD,TYPEID")] BILL bILL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bILL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CUSTOMERID = new SelectList(db.CUSTOMER, "CUSTOMERID", "USERNAME", bILL.CUSTOMERID);
            ViewBag.TYPEID = new SelectList(db.BILL_TYPE, "TYPEID", "TYPE_NAME", bILL.TYPEID);
            return View(bILL);
        }

        // GET: BILLs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BILL bILL = db.BILL.Find(id);
            if (bILL == null)
            {
                return HttpNotFound();
            }
            return View(bILL);
        }

        // POST: BILLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BILL bILL = db.BILL.Find(id);
            BILL_PRODUCTS bILL_PRODUCTS = db.BILL_PRODUCTS.Where(x=> x.BILLID==id).ToList().First();
            db.BILL_PRODUCTS.Remove(bILL_PRODUCTS);
            db.BILL.Remove(bILL);
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
