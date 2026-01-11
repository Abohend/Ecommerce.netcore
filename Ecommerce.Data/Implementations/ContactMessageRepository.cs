using Ecommerce.DataAccess.Data;
using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;

namespace Ecommerce.DataAccess.Implementations
{
    internal class ContactMessageRepository : GenericRepository<ContactMessage>, IContactMessageRepository
    {
        public ContactMessageRepository(Context context) : base(context)
        {
        }
    }
}
