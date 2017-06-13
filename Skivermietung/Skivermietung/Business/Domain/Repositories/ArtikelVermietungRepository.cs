using System.Collections.Generic;
using Skivermietung.Business.Domain.Repositories.Interfaces;
using Skivermietung.Models;

namespace Skivermietung.Business.Domain.Repositories
{
	internal class ArtikelVermietungRepository : RepositoryBase<ArtikelVermietung>, IArtikelVermietungRepository
	{
		public ArtikelVermietungRepository(SkivermietungContext context)
			: base(context)
		{
		}

		public IEnumerable<ArtikelVermietung> LoadByVermietung(int idVermietung)
		{
			return Search(x => x.VermietungsId == idVermietung);
		}
	}
}