using Skivermietung.Business.Domain.Repositories;
using Skivermietung.Business.Domain.Repositories.Interfaces;
using Skivermietung.Models;

namespace Skivermietung.Business.Domain
{
	internal class UnitOfWork : IUnitOfWork
	{
		private readonly SkivermietungContext _context;

		public UnitOfWork(SkivermietungContext context)
		{
			_context = context;

			Benutzer = new BenutzerRepository(_context);
		}

		public IBenutzerRepository Benutzer { get; private set; }

		public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}