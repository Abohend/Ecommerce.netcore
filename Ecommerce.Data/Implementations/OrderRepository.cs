using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Implementations;
using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;

namespace Ecommerce.DataِAccess.Implementations
{
    internal class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(Context context) : base(context)
        {
        }
    }
}
