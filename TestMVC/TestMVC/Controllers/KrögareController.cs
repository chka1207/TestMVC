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
    public class KrögareController : Controller
    {
        private DatabasContext db = new DatabasContext();


        //public ActionResult DisplayByKrögare(int krögareID)  //Egen metod
        //{
        //    //Här ska kod in
        //    return View();
        //}

        // GET: Krögare
        public ActionResult Index()
        {
            return View(db.Krögare.ToList());
        }

        // GET: Krögare/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Krögare krögare = db.Krögare.Find(id);
            if (krögare == null)
            {
                return HttpNotFound();
            }
            return View(krögare);
        }

        // GET: Krögare/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Krögare/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KrögareID,Förnamn,Efternamn,Adress,Postnummer,Ort,Mobilnummer,Email")] Krögare krögare)
        {
            if (ModelState.IsValid)
            {
                db.Krögare.Add(krögare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(krögare);
        }

        // GET: Krögare/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Krögare krögare = db.Krögare.Find(id);
            if (krögare == null)
            {
                return HttpNotFound();
            }
            return View(krögare);
        }

        // POST: Krögare/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KrögareID,Förnamn,Efternamn,Adress,Postnummer,Ort,Mobilnummer,Email")] Krögare krögare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(krögare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(krögare);
        }

        // GET: Krögare/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Krögare krögare = db.Krögare.Find(id);
            if (krögare == null)
            {
                return HttpNotFound();
            }
            return View(krögare);
        }

        // POST: Krögare/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Krögare krögare = db.Krögare.Find(id);
            db.Krögare.Remove(krögare);
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
