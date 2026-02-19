using Ecommerce.DataAccess.Data;
using Ecommerce.DataِAccess.Implementations;
using Ecommerce.Entities.Repositories;
namespace Ecommerce.DataAccess.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; }
        public IShoppingCartReposiotry ShoppingCart { get; }
        public IOrderRepository Order { get; }
        public IOrderItemRepository OrderItem { get; }
        public IContactInfoRepository ContactInfo { get; }
        public IContactMessageRepository ContactMessage { get; }
        public IWebsiteViewRepository WebsiteView { get; }

        public UnitOfWork(Context context)
        {
            this.Category = new CategoryRepository(context);
            this.Product = new ProductRepository(context);
            this.ShoppingCart = new ShoppingCartRepository(context);
            this.Order = new OrderRepository(context);
            this.OrderItem = new OrderItemRepository(context);
            this.ContactInfo = new ContactInfoRepository(context);
            this.ContactMessage = new ContactMessageRepository(context);
            this.WebsiteView = new WebsiteViewRepository(context);
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
