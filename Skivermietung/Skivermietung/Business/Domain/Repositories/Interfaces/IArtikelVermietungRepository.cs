using System.Collections.Generic;
using Skivermietung.Models;

namespace Skivermietung.Business.Domain.Repositories.Interfaces
{
	public interface IArtikelVermietungRepository : IRepositoryBase<ArtikelVermietung>
	{
		IEnumerable<ArtikelVermietung> LoadByVermietung(int idVermietung);
	}
}