using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EmoPicturesController : Controller
    {
        private WebApplication2Context db = new WebApplication2Context();

        // GET: EmoPictures
        public ActionResult Index()
        {
            return View(db.EmoPictures.ToList());
        }

        // GET: EmoPictures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmoPicture emoPicture = db.EmoPictures.Find(id);
            if (emoPicture == null)
            {
                return HttpNotFound();
            }
            return View(emoPicture);
        }

        // GET: EmoPictures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmoPictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Path")] EmoPicture emoPicture)
        {
            if (ModelState.IsValid)
            {
                db.EmoPictures.Add(emoPicture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emoPicture);
        }

        // GET: EmoPictures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmoPicture emoPicture = db.EmoPictures.Find(id);
            if (emoPicture == null)
            {
                return HttpNotFound();
            }
            return View(emoPicture);
        }

        // POST: EmoPictures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Path")] EmoPicture emoPicture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emoPicture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emoPicture);
        }

        // GET: EmoPictures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmoPicture emoPicture = db.EmoPictures.Find(id);
            if (emoPicture == null)
            {
                return HttpNotFound();
            }
            return View(emoPicture);
        }

        // POST: EmoPictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmoPicture emoPicture = db.EmoPictures.Find(id);
            db.EmoPictures.Remove(emoPicture);
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
