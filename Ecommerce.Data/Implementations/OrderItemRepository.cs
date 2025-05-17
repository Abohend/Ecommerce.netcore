using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Implementations;
using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;

namespace Ecommerce.DataِAccess.Implementations
{
    internal class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(Context context) : base(context)
        {
        }
    }
}
