using Ecommerce.Entities.Models;

namespace Ecommerce.Entities.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        int Complete();
    }
}
