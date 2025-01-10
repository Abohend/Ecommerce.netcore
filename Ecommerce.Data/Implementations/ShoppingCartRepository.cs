using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Implementations;
using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;

namespace Ecommerce.DataِAccess.Implementations
{
    internal class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartReposiotry
    {
        public ShoppingCartRepository(Context context) : base(context)
        {
        }
    }
}
