using Ecommerce.DataAccess.Data;
using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;

namespace Ecommerce.DataAccess.Implementations
{
    internal class ContactInfoRepository : GenericRepository<ContactInfo>, IContactInfoRepository
    {
        public ContactInfoRepository(Context context) : base(context)
        {
        }
    }
}
