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
    public class VaktController : Controller
    {
        private DatabasContext db = new DatabasContext();

        // GET: Vakt
        public ActionResult Index()
        {
            return View(db.Vakts.ToList());
        }

        // GET: Vakt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vakt vakt = db.Vakts.Find(id);
            if (vakt == null)
            {
                return HttpNotFound();
            }
            return View(vakt);
        }

        // GET: Vakt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vakt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VaktID,Förnamn,Efternamn,Adress,Postnummer,Ort,Mobilnummer,Email")] Vakt vakt)
        {
            if (ModelState.IsValid)
            {
                db.Vakts.Add(vakt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vakt);
        }

        // GET: Vakt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vakt vakt = db.Vakts.Find(id);
            if (vakt == null)
            {
                return HttpNotFound();
            }
            return View(vakt);
        }

        // POST: Vakt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VaktID,Förnamn,Efternamn,Adress,Postnummer,Ort,Mobilnummer,Email")] Vakt vakt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vakt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vakt);
        }

        // GET: Vakt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vakt vakt = db.Vakts.Find(id);
            if (vakt == null)
            {
                return HttpNotFound();
            }
            return View(vakt);
        }

        // POST: Vakt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vakt vakt = db.Vakts.Find(id);
            db.Vakts.Remove(vakt);
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
