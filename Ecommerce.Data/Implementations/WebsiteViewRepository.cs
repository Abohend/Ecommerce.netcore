using Ecommerce.DataAccess.Data;
using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Implementations
{
    internal class WebsiteViewRepository : GenericRepository<WebsiteView>, IWebsiteViewRepository
    {
        private readonly Context _context;

        public WebsiteViewRepository(Context context) : base(context)
        {
            _context = context;
        }
    }
}
