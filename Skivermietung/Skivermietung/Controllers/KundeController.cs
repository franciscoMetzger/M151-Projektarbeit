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
	public class KundeController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public KundeController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// GET: Kunde
		public ActionResult Index()
		{
			return View(_unitOfWork.Kunde.LoadAll());
		}

		// GET: Kunde/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Kunde kunde = _unitOfWork.Kunde.Load(id.Value);
			if (kunde == null)
			{
				return HttpNotFound();
			}
			return View(kunde);
		}

		// GET: Kunde/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Kunde/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID_Kunde,Vorname,Name,TelefonNr,Geburtstag")] Kunde kunde)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Kunde.Insert(kunde);
				_unitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(kunde);
		}

		// GET: Kunde/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Kunde kunde = _unitOfWork.Kunde.Load(id.Value);
			if (kunde == null)
			{
				return HttpNotFound();
			}
			return View(kunde);
		}

		// POST: Kunde/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID_Kunde,Vorname,Name,TelefonNr,Geburtstag")] Kunde kunde)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Kunde.Update(kunde);
				_unitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(kunde);
		}

		// GET: Kunde/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Kunde kunde = _unitOfWork.Kunde.Load(id.Value);
			if (kunde == null)
			{
				return HttpNotFound();
			}
			return View(kunde);
		}

		// POST: Kunde/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Kunde kunde = _unitOfWork.Kunde.Load(id);
			_unitOfWork.Kunde.Delete(kunde);
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
