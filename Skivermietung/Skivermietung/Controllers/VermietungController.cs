﻿using System;
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
using WebGrease.Css.Extensions;

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

			ViewBag.VermietungArtikel = vermietung.ArtikelVermietung.Select(x => x.Artikel);

			return View(vermietung);
		}

		// GET: Vermietung/Create
		public ActionResult Create()
		{
			ViewBag.KundeId = new SelectList(_kundenSelection, "ID_Kunde", "Vorname");
			ViewBag.Artikel = _unitOfWork.Artikel.LoadAll().ToList();
			return View();
		}

		// POST: Vermietung/Create
		[HttpPost]
		public ActionResult Create(Vermietung vermietung)
		{
			if (ModelState.IsValid)
			{
				if (vermietung.Artikel != null)
				{
					foreach (var artikelId in vermietung.Artikel)
					{
						vermietung.AddArtikel(artikelId);
					}
				}

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
			ViewBag.Artikel = _unitOfWork.Artikel.LoadAll().ToList();

			return View(vermietung);
		}

		// POST: Vermietung/Edit/5
		[HttpPost]
		public ActionResult Edit(Vermietung vermietung)
		{
			if (ModelState.IsValid)
			{
				if (vermietung.Artikel != null)
				{
					var existingArtikelVermietungen = _unitOfWork.ArtikelVermietung.LoadByVermietung(vermietung.ID_Vermietung).ToList();

					foreach (var artikelVermietung in existingArtikelVermietungen)
					{
						if (vermietung.Artikel.Contains(artikelVermietung.ArtikelId) == false)
						{
							_unitOfWork.ArtikelVermietung.Delete(artikelVermietung);
						}
					}

					foreach (var artikelId in vermietung.Artikel)
					{
						if (existingArtikelVermietungen.Any(x => x.ArtikelId == artikelId) == false)
						{
							var newItem = new ArtikelVermietung { ArtikelId = artikelId, VermietungsId = vermietung.ID_Vermietung };
							_unitOfWork.ArtikelVermietung.Insert(newItem);
							vermietung.ArtikelVermietung.Add(newItem);
						}
					}
				}
				else
				{
					vermietung.ArtikelVermietung.Clear();
				}

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

			vermietung.ArtikelVermietung.ToList().ForEach(x => _unitOfWork.ArtikelVermietung.Delete(x));
			_unitOfWork.Vermietung.Delete(vermietung);

			_unitOfWork.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Bezahlt(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var vermietung = _unitOfWork.Vermietung.Load(id.Value);
			vermietung.Bezahlt = DateTime.Now;

			_unitOfWork.Vermietung.Update(vermietung);
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
