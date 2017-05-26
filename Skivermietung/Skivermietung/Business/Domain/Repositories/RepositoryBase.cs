using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Skivermietung.Business.Domain.Repositories.Interfaces;
using Skivermietung.Models;

namespace Skivermietung.Business.Domain.Repositories
{
	public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
	{
		private readonly SkivermietungContext _dbContext;

		public RepositoryBase(SkivermietungContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Insert(TEntity entity)
		{
			_dbContext.Set<TEntity>().Add(entity);
		}

		public void Delete(TEntity entity)
		{
			_dbContext.Set<TEntity>().Remove(entity);
		}

		public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
		{
			return _dbContext.Set<TEntity>().Where(predicate);
		}

		public IEnumerable<TEntity> LoadAll()
		{
			return _dbContext.Set<TEntity>();
		}

		public TEntity Load(int id)
		{
			return _dbContext.Set<TEntity>().Find(id);
		}
	}
}