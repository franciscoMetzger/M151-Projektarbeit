using Skivermietung.Business.Domain.Repositories.Interfaces;

namespace Skivermietung.Business.Domain
{
	public interface IUnitOfWork
	{
		IArtikelRepository Artikel { get; }
		IVermietungRepository Vermietung { get; }
		IArtikelVermietungRepository ArtikelVermietung { get; }
		IKategorieRepository Kategorie { get; }
		IKundeRepository Kunde { get; }
		IBenutzerRepository Benutzer { get; }

		void SaveChanges();
	}
}