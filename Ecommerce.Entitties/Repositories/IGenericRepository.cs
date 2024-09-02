using System.Linq.Expressions;

namespace Ecommerce.Entities.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeEntities = null );
        T? GetOne(Expression<Func<T, bool>>? predicate = null, string? includeEntities = null);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> Entities);
    }
}
