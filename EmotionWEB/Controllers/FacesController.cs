using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmotionWEB.Data;
using EmotionWEB.Models;

namespace EmotionWEB.Controllers
{
    public class FacesController : Controller
    {
        private EmotionWEBContext db = new EmotionWEBContext();

        // GET: Faces
        public ActionResult Index()
        {
            var faces = db.Faces.Include(f => f.picture);
            return View(faces.ToList());
        }

        // GET: Faces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Face face = db.Faces.Find(id);
            if (face == null)
            {
                return HttpNotFound();
            }
            return View(face);
        }

        // GET: Faces/Create
        public ActionResult Create()
        {
            ViewBag.PictureId = new SelectList(db.Pictures, "Id", "Name");
            return View();
        }

        // POST: Faces/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PictureId,X,Y,Width,Height")] Face face)
        {
            if (ModelState.IsValid)
            {
                db.Faces.Add(face);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PictureId = new SelectList(db.Pictures, "Id", "Name", face.PictureId);
            return View(face);
        }

        // GET: Faces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Face face = db.Faces.Find(id);
            if (face == null)
            {
                return HttpNotFound();
            }
            ViewBag.PictureId = new SelectList(db.Pictures, "Id", "Name", face.PictureId);
            return View(face);
        }

        // POST: Faces/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PictureId,X,Y,Width,Height")] Face face)
        {
            if (ModelState.IsValid)
            {
                db.Entry(face).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PictureId = new SelectList(db.Pictures, "Id", "Name", face.PictureId);
            return View(face);
        }

        // GET: Faces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Face face = db.Faces.Find(id);
            if (face == null)
            {
                return HttpNotFound();
            }
            return View(face);
        }

        // POST: Faces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Face face = db.Faces.Find(id);
            db.Faces.Remove(face);
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
