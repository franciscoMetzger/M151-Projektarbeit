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
	}
}