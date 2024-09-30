using Ecommerce.DataAccess.Data;
using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;
namespace Ecommerce.DataAccess.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public ICategoryRepository Category { get; private set; }

        public IProductRepository Product { get; }

        public UnitOfWork(Context context)
        {
            this.Category = new CategoryRepository(context);
            this.Product = new ProductRepository(context);
            this._context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
