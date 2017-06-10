using Skivermietung.Business.Domain.Repositories.Interfaces;
using Skivermietung.Models;

namespace Skivermietung.Business.Domain
{
	internal class UnitOfWork : IUnitOfWork
	{
		private readonly SkivermietungContext _context;

		public UnitOfWork(SkivermietungContext context,
			IArtikelRepository artikel,
			IVermietungRepository vermietung,
			IArtikelVermietungRepository artikelVermietung,
			IKategorieRepository kategorie,
			IKundeRepository kunde,
			IBenutzerRepository benutzer)
		{
			_context = context;

			Artikel = artikel;
			Vermietung = vermietung;
			ArtikelVermietung = artikelVermietung;
			Kategorie = kategorie;
			Kunde = kunde;
			Benutzer = benutzer;
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