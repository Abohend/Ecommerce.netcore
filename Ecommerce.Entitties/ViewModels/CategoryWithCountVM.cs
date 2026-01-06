namespace Ecommerce.Entities.ViewModels
{
    public class CategoryWithCountVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ProductCount { get; set; }
    }
}
