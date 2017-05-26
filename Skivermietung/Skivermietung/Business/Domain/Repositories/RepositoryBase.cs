using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Skivermietung.Business.Domain.Repositories.Interfaces;
using Skivermietung.Models;

namespace Skivermietung.Business.Domain.Repositories
{
	internal class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
	{
		private readonly SkivermietungContext _context;

		public RepositoryBase(SkivermietungContext context)
		{
			_context = context;
		}

		public void Insert(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);
		}

		public void Delete(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
		}

		public void Update(TEntity entity)
		{
			_context.Set<TEntity>().Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
		}

		public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
		{
			return _context.Set<TEntity>().Where(predicate);
		}

		public IEnumerable<TEntity> LoadAll()
		{
			return _context.Set<TEntity>();
		}

		public TEntity Load(int id)
		{
			return _context.Set<TEntity>().Find(id);
		}
	}
}