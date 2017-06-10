using Skivermietung.Business.Domain.Repositories.Interfaces;
using Skivermietung.Models;

namespace Skivermietung.Business.Domain.Repositories
{
	internal class KundeRepository : RepositoryBase<Kunde>, IKundeRepository
	{
		public KundeRepository(SkivermietungContext context)
			: base(context)
		{
		}
	}
}