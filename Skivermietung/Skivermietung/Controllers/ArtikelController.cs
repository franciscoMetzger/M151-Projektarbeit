using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Skivermietung.Business.Domain;
using Skivermietung.Models;

namespace Skivermietung.Controllers
{
	public class ArtikelController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly List<Kategorie> _kategorieSelection;

		public ArtikelController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;

			_kategorieSelection = new List<Kategorie>(_unitOfWork.Kategorie.LoadAll());
		}

		// GET: Artikel
		public ActionResult Index()
		{
			var artikel = _unitOfWork.Artikel.LoadAll();
			return View(artikel.ToList());
		}

		// GET: Artikel/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Artikel artikel = _unitOfWork.Artikel.Load(id.Value);
			if (artikel == null)
			{
				return HttpNotFound();
			}
			return View(artikel);
		}

		// GET: Artikel/Create
		public ActionResult Create()
		{
			ViewBag.KategorieId = new SelectList(_kategorieSelection, "ID_Kategorie", "Bezeichnung");
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
				_unitOfWork.Artikel.Insert(artikel);
				_unitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.KategorieId = new SelectList(_kategorieSelection, "ID_Kategorie", "Bezeichnung", artikel.KategorieId);
			return View(artikel);
		}

		// GET: Artikel/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Artikel artikel = _unitOfWork.Artikel.Load(id.Value);
			if (artikel == null)
			{
				return HttpNotFound();
			}
			ViewBag.KategorieId = new SelectList(_kategorieSelection, "ID_Kategorie", "Bezeichnung", artikel.KategorieId);
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
				_unitOfWork.Artikel.Update(artikel);
				_unitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.KategorieId = new SelectList(_kategorieSelection, "ID_Kategorie", "Bezeichnung", artikel.KategorieId);
			return View(artikel);
		}

		// GET: Artikel/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Artikel artikel = _unitOfWork.Artikel.Load(id.Value);
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
			Artikel artikel = _unitOfWork.Artikel.Load(id);
			_unitOfWork.Artikel.Delete(artikel);
			_unitOfWork.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_unitOfWork.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
