using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Skivermietung.Business.Domain;
using Skivermietung.Business.Domain.Repositories.Interfaces;
using Skivermietung.Models;

namespace Skivermietung.Controllers
{
	public class VermietungController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		private readonly List<Kunde> _kundenSelection;

		public VermietungController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;

			_kundenSelection = new List<Kunde>(_unitOfWork.Kunde.LoadAll());
		}

		// GET: Vermietung
		public ActionResult Index()
		{
			return View(_unitOfWork.Vermietung.LoadAll());
		}

		// GET: Vermietung/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Vermietung vermietung = _unitOfWork.Vermietung.Load(id.Value);
			if (vermietung == null)
			{
				return HttpNotFound();
			}
			return View(vermietung);
		}

		// GET: Vermietung/Create
		public ActionResult Create()
		{
			ViewBag.KundeId = new SelectList(_kundenSelection, "ID_Kunde", "Vorname");
			return View();
		}

		// POST: Vermietung/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID_Vermietung,Von,Bis,Bezahlt,Rabatt,KundeId")] Vermietung vermietung)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Vermietung.Insert(vermietung);
				_unitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.KundeId = new SelectList(_kundenSelection, "ID_Kunde", "Vorname", vermietung.KundeId);
			return View(vermietung);
		}

		// GET: Vermietung/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Vermietung vermietung = _unitOfWork.Vermietung.Load(id.Value);
			if (vermietung == null)
			{
				return HttpNotFound();
			}
			ViewBag.KundeId = new SelectList(_kundenSelection, "ID_Kunde", "Vorname", vermietung.KundeId);
			return View(vermietung);
		}

		// POST: Vermietung/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID_Vermietung,Von,Bis,Bezahlt,Rabatt,KundeId")] Vermietung vermietung)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Vermietung.Update(vermietung);
				_unitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.KundeId = new SelectList(_kundenSelection, "ID_Kunde", "Vorname", vermietung.KundeId);
			return View(vermietung);
		}

		// GET: Vermietung/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Vermietung vermietung = _unitOfWork.Vermietung.Load(id.Value);
			if (vermietung == null)
			{
				return HttpNotFound();
			}
			return View(vermietung);
		}

		// POST: Vermietung/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Vermietung vermietung = _unitOfWork.Vermietung.Load(id);
			_unitOfWork.Vermietung.Delete(vermietung);
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
