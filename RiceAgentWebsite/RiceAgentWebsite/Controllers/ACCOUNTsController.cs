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
    public class ACCOUNTsController : Controller
    {
        private RAMS_DBSEntities db = new RAMS_DBSEntities();

        // GET: ACCOUNTs
        public ActionResult Index()
        {
            return View(db.ACCOUNT.ToList());
        }

        // GET: ACCOUNTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACCOUNT aCCOUNT = db.ACCOUNT.Find(id);
            if (aCCOUNT == null)
            {
                return HttpNotFound();
            }
            return View(aCCOUNT);
        }

        // GET: ACCOUNTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ACCOUNTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "USERNAME,PASSWORD")] ACCOUNT aCCOUNT)
        {
            if (ModelState.IsValid)
            {
                db.ACCOUNT.Add(aCCOUNT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aCCOUNT);
        }

        // GET: ACCOUNTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACCOUNT aCCOUNT = db.ACCOUNT.Find(id);
            if (aCCOUNT == null)
            {
                return HttpNotFound();
            }
            return View(aCCOUNT);
        }

        // POST: ACCOUNTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "USERNAME,PASSWORD")] ACCOUNT aCCOUNT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCCOUNT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aCCOUNT);
        }

        // GET: ACCOUNTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACCOUNT aCCOUNT = db.ACCOUNT.Find(id);
            if (aCCOUNT == null)
            {
                return HttpNotFound();
            }
            return View(aCCOUNT);
        }

        // POST: ACCOUNTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ACCOUNT aCCOUNT = db.ACCOUNT.Find(id);
            db.ACCOUNT.Remove(aCCOUNT);
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
