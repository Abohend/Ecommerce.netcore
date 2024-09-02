using Ecommerce.DataAccess.Data;
using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;

namespace Ecommerce.DataAccess.Implementations
{
    internal class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(Context context) : base(context)
        {
        }
    }
}
