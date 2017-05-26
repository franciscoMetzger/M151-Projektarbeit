using System.Linq;
using Skivermietung.Business.Domain.Repositories.Interfaces;
using Skivermietung.Models;

namespace Skivermietung.Business.Domain.Repositories
{
	internal class BenutzerRepository : RepositoryBase<Benutzer>, IBenutzerRepository
	{
		public BenutzerRepository(SkivermietungContext context)
			: base(context)
		{
		}

		public Benutzer LoadByUsername(string username)
		{
			return Search(x => x.Benutzername == username).SingleOrDefault();
		}

		public bool Exists(string username)
		{
			return Search(x => x.Benutzername == username).Any();
		}
	}
}