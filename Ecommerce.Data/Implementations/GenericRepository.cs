using Ecommerce.DataAccess.Data;
using Ecommerce.Entities.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.DataAccess.Implementations
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Context _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(Context context)
        {
            this._context = context;
            _dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeEntities = null)
        {
            var query = _dbSet.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeEntities != null)
            {
                includeEntities.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                    .ForEach(entity =>
                    {
                        query = query.Include(entity);
                    });
            }
            return query.ToList();
        }

        public T? GetOne(Expression<Func<T, bool>>? predicate = null, string? includeEntities = null)
        {
            var query = _dbSet.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeEntities != null)
            {
                includeEntities.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                .ForEach(entity =>
                {
                        query = query.Include(entity);
                    });
            }
            return query.SingleOrDefault();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> Entities)
        {
            _dbSet.RemoveRange(Entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
