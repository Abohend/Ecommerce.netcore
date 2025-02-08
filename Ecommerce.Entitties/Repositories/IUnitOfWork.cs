namespace Ecommerce.Entities.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IShoppingCartReposiotry ShoppingCart { get; }
        IOrderRepository Order { get; }
        int Complete();
    }
}
