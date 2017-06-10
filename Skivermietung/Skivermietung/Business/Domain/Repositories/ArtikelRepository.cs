using Skivermietung.Business.Domain.Repositories.Interfaces;
using Skivermietung.Models;

namespace Skivermietung.Business.Domain.Repositories
{
	internal class ArtikelRepository : RepositoryBase<Artikel>, IArtikelRepository
	{
		public ArtikelRepository(SkivermietungContext context)
			: base(context)
		{
		}
	}
}