using Skivermietung.Business.Domain.Repositories;
using Skivermietung.Business.Domain.Repositories.Interfaces;
using Skivermietung.Models;

namespace Skivermietung.Business.Domain
{
	internal class UnitOfWork : IUnitOfWork
	{
		private readonly SkivermietungContext _context;

		public UnitOfWork(SkivermietungContext context)
		{
			_context = context;

			Artikel = new ArtikelRepository(_context);
			Vermietung = new VermietungRepository(_context);
			ArtikelVermietung = new ArtikelVermietungRepository(_context);
			Kategorie = new KategorieRepository(_context);
			Kunde = new KundeRepository(_context);
			Benutzer = new BenutzerRepository(_context);
		}

		public IArtikelRepository Artikel { get; private set; }
		public IVermietungRepository Vermietung { get; private set; }
		public IArtikelVermietungRepository ArtikelVermietung { get; private set; }
		public IKategorieRepository Kategorie { get; private set; }
		public IKundeRepository Kunde { get; private set; }
		public IBenutzerRepository Benutzer { get; private set; }

		public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}