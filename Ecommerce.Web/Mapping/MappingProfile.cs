using AutoMapper;
using Ecommerce.Entities.Models;
using Ecommerce.Entities.ViewModels;

namespace Ecommerce.Web.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductVM>();
            CreateMap<Category, CategoryWithCountVM>();
            CreateMap<ShopQueryVM, ShopVM>();
        }
    }
}
