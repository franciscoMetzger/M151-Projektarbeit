using Skivermietung.Business.Domain.Repositories.Interfaces;
using Skivermietung.Models;

namespace Skivermietung.Business.Domain.Repositories
{
	internal class KategorieRepository : RepositoryBase<Kategorie>, IKategorieRepository
	{
		public KategorieRepository(SkivermietungContext context)
			: base(context)
		{
		}
	}
}