﻿using System;
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
    public class EmotionsController : Controller
    {
        private EmotionWEBContext db = new EmotionWEBContext();

        // GET: Emotions
        public ActionResult Index()
        {
            return View(db.Emotions.ToList());
        }

        // GET: Emotions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emotion emotion = db.Emotions.Find(id);
            if (emotion == null)
            {
                return HttpNotFound();
            }
            return View(emotion);
        }

        // GET: Emotions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emotions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Score")] Emotion emotion)
        {
            if (ModelState.IsValid)
            {
                db.Emotions.Add(emotion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emotion);
        }

        // GET: Emotions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emotion emotion = db.Emotions.Find(id);
            if (emotion == null)
            {
                return HttpNotFound();
            }
            return View(emotion);
        }

        // POST: Emotions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Score")] Emotion emotion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emotion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emotion);
        }

        // GET: Emotions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emotion emotion = db.Emotions.Find(id);
            if (emotion == null)
            {
                return HttpNotFound();
            }
            return View(emotion);
        }

        // POST: Emotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emotion emotion = db.Emotions.Find(id);
            db.Emotions.Remove(emotion);
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