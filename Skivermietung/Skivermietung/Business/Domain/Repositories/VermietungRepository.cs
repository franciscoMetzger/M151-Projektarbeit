using Skivermietung.Business.Domain.Repositories.Interfaces;
using Skivermietung.Models;

namespace Skivermietung.Business.Domain.Repositories
{
	internal class VermietungRepository : RepositoryBase<Vermietung>, IVermietungRepository
	{
		public VermietungRepository(SkivermietungContext context)
			: base(context)
		{
		}
	}
}