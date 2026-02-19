namespace Ecommerce.Entities.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IShoppingCartReposiotry ShoppingCart { get; }
        IOrderRepository Order { get; }
        IOrderItemRepository OrderItem { get; }
        IContactInfoRepository ContactInfo { get; }
        IContactMessageRepository ContactMessage { get; }
        IWebsiteViewRepository WebsiteView { get; }
        int Complete();
    }
}
