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
	public class KategorieController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public KategorieController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// GET: Kategorie
		public ActionResult Index()
		{
			return View(_unitOfWork.Kategorie.LoadAll());
		}

		// GET: Kategorie/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Kategorie kategorie = _unitOfWork.Kategorie.Load(id.Value);
			if (kategorie == null)
			{
				return HttpNotFound();
			}
			return View(kategorie);
		}

		// GET: Kategorie/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Kategorie/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID_Kategorie,Bezeichnung")] Kategorie kategorie)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Kategorie.Insert(kategorie);
				_unitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(kategorie);
		}

		// GET: Kategorie/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Kategorie kategorie = _unitOfWork.Kategorie.Load(id.Value);
			if (kategorie == null)
			{
				return HttpNotFound();
			}
			return View(kategorie);
		}

		// POST: Kategorie/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID_Kategorie,Bezeichnung")] Kategorie kategorie)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Kategorie.Update(kategorie);
				_unitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(kategorie);
		}

		// GET: Kategorie/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Kategorie kategorie = _unitOfWork.Kategorie.Load(id.Value);
			if (kategorie == null)
			{
				return HttpNotFound();
			}
			return View(kategorie);
		}

		// POST: Kategorie/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Kategorie kategorie = _unitOfWork.Kategorie.Load(id);
			_unitOfWork.Kategorie.Delete(kategorie);
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
