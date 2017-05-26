using Skivermietung.Business.Domain.Repositories.Interfaces;

namespace Skivermietung.Business.Domain
{
	public interface IUnitOfWork
	{
		IBenutzerRepository Benutzer { get; }

		void SaveChanges();
	}
}