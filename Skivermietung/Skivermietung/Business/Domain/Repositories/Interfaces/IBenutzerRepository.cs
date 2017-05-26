using Skivermietung.Models;

namespace Skivermietung.Business.Domain.Repositories.Interfaces
{
	public interface IBenutzerRepository : IRepositoryBase<Benutzer>
	{
		Benutzer LoadByUsername(string username);
		bool Exists(string username);
	}
}