using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;

namespace TestMVC.Controllers
{
    public class PassController : Controller
    {
        private PassContext db = new PassContext();

        // GET: Pass
        public ActionResult Index()
        {
            return View(db.Passes.ToList());
        }

        // GET: Pass/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pass pass = db.Passes.Find(id);
            if (pass == null)
            {
                return HttpNotFound();
            }
            return View(pass);
        }

        // GET: Pass/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PassID,Datum,Start,Slut")] Pass pass)
        {
            if (ModelState.IsValid)
            {
                db.Passes.Add(pass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pass);
        }

        // GET: Pass/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pass pass = db.Passes.Find(id);
            if (pass == null)
            {
                return HttpNotFound();
            }
            return View(pass);
        }

        // POST: Pass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PassID,Datum,Start,Slut")] Pass pass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pass);
        }

        // GET: Pass/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pass pass = db.Passes.Find(id);
            if (pass == null)
            {
                return HttpNotFound();
            }
            return View(pass);
        }

        // POST: Pass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pass pass = db.Passes.Find(id);
            db.Passes.Remove(pass);
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
