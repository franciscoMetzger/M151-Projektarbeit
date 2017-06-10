﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Skivermietung.Models;

namespace Skivermietung.Controllers
{
    public class ArtikelController : Controller
    {
        private SkivermietungContext db = new SkivermietungContext();

        // GET: Artikel
        public ActionResult Index()
        {
            var artikel = db.Artikel.Include(a => a.Kategorie);
            return View(artikel.ToList());
        }

        // GET: Artikel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikel artikel = db.Artikel.Find(id);
            if (artikel == null)
            {
                return HttpNotFound();
            }
            return View(artikel);
        }

        // GET: Artikel/Create
        public ActionResult Create()
        {
            ViewBag.KategorieId = new SelectList(db.Kategorie, "ID_Kategorie", "Bezeichnung");
            return View();
        }

        // POST: Artikel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Artikel,Bezeichnung,Farbe,Marke,PreisProTag,KategorieId")] Artikel artikel)
        {
            if (ModelState.IsValid)
            {
                db.Artikel.Add(artikel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategorieId = new SelectList(db.Kategorie, "ID_Kategorie", "Bezeichnung", artikel.KategorieId);
            return View(artikel);
        }

        // GET: Artikel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikel artikel = db.Artikel.Find(id);
            if (artikel == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategorieId = new SelectList(db.Kategorie, "ID_Kategorie", "Bezeichnung", artikel.KategorieId);
            return View(artikel);
        }

        // POST: Artikel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Artikel,Bezeichnung,Farbe,Marke,PreisProTag,KategorieId")] Artikel artikel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artikel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategorieId = new SelectList(db.Kategorie, "ID_Kategorie", "Bezeichnung", artikel.KategorieId);
            return View(artikel);
        }

        // GET: Artikel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikel artikel = db.Artikel.Find(id);
            if (artikel == null)
            {
                return HttpNotFound();
            }
            return View(artikel);
        }

        // POST: Artikel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artikel artikel = db.Artikel.Find(id);
            db.Artikel.Remove(artikel);
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
