using Ecommerce.DataAccess.Data;
using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;

namespace Ecommerce.DataAccess.Implementations
{
    internal class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(Context context) : base(context)
        {
        }
    }
}
