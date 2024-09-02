using Ecommerce.DataAccess.Data;
using Ecommerce.Entities.Repositories;
namespace Ecommerce.DataAccess.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(Context context)
        {
            this.Category = new CategoryRepository(context);
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
