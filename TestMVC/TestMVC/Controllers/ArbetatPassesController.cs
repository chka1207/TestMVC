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
    public class ArbetatPassesController : Controller
    {
        private ArbetatPassContext db = new ArbetatPassContext();

        // GET: ArbetatPasses
        public ActionResult Index()
        {
            return View(db.ArbetatPasses.ToList());
        }

        // GET: ArbetatPasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArbetatPass arbetatPass = db.ArbetatPasses.Find(id);
            if (arbetatPass == null)
            {
                return HttpNotFound();
            }
            return View(arbetatPass);
        }

        // GET: ArbetatPasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArbetatPasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArbetatPassID,Datum,Start,Slut")] ArbetatPass arbetatPass)
        {
            if (ModelState.IsValid)
            {
                db.ArbetatPasses.Add(arbetatPass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arbetatPass);
        }

        // GET: ArbetatPasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArbetatPass arbetatPass = db.ArbetatPasses.Find(id);
            if (arbetatPass == null)
            {
                return HttpNotFound();
            }
            return View(arbetatPass);
        }

        // POST: ArbetatPasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArbetatPassID,Datum,Start,Slut")] ArbetatPass arbetatPass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arbetatPass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arbetatPass);
        }

        // GET: ArbetatPasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArbetatPass arbetatPass = db.ArbetatPasses.Find(id);
            if (arbetatPass == null)
            {
                return HttpNotFound();
            }
            return View(arbetatPass);
        }

        // POST: ArbetatPasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArbetatPass arbetatPass = db.ArbetatPasses.Find(id);
            db.ArbetatPasses.Remove(arbetatPass);
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
