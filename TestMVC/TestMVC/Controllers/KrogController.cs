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
    public class KrogController : Controller
    {
        private DatabasContext db = new DatabasContext();

        // GET: Krog
        public ActionResult Index()
        {
            return View(db.Krogs.ToList());
        }

        // GET: Krog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Krog krog = db.Krogs.Find(id);
            if (krog == null)
            {
                return HttpNotFound();
            }
            return View(krog);
        }

        // GET: Krog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Krog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KrogID,Namn,Adress,Postnummer,Ort")] Krog krog)
        {
            if (ModelState.IsValid)
            {
                db.Krogs.Add(krog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(krog);
        }

        // GET: Krog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Krog krog = db.Krogs.Find(id);
            if (krog == null)
            {
                return HttpNotFound();
            }
            return View(krog);
        }

        // POST: Krog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KrogID,Namn,Adress,Postnummer,Ort")] Krog krog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(krog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(krog);
        }

        // GET: Krog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Krog krog = db.Krogs.Find(id);
            if (krog == null)
            {
                return HttpNotFound();
            }
            return View(krog);
        }

        // POST: Krog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Krog krog = db.Krogs.Find(id);
            db.Krogs.Remove(krog);
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
