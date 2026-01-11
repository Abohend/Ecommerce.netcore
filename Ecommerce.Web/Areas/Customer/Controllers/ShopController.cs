using AutoMapper;
using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;
using Ecommerce.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Claims;
using X.PagedList.Extensions;

namespace Ecommerce.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShopController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShopController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public IActionResult Index(ShopQueryVM shopQuery)
        {
            var acceptHeader = Request.Headers["Accept"].ToString();

            Expression<Func<Product, bool>>? filterPredicate = null;
            if (shopQuery.CategoryId.HasValue || 
                !string.IsNullOrWhiteSpace(shopQuery.Search) ||
                shopQuery.MinPrice.HasValue ||
                shopQuery.MaxPrice.HasValue)
            {
                var term = shopQuery.Search?.Trim();

                filterPredicate = p =>
                    (!shopQuery.CategoryId.HasValue || p.CategoryId == shopQuery.CategoryId.GetValueOrDefault()) &&
                    (string.IsNullOrEmpty(term) ||
                        p.Name.Contains(term) ||
                        p.Description.Contains(term)) && 
                    (!shopQuery.MinPrice.HasValue || p.Price >= shopQuery.MinPrice) && 
                    (!shopQuery.MaxPrice.HasValue || p.Price <= shopQuery.MaxPrice);
            }

            var query = _unitOfWork.Product.GetAll(filterPredicate, includeEntities: "Category");
            query = shopQuery.Sort switch
            {
                "price_asc" => query.OrderBy(p => p.Price),
                "price_desc" => query.OrderByDescending(p => p.Price),
                _ => query
            };

            // json response
            if (!string.IsNullOrEmpty(acceptHeader) && acceptHeader.Contains("application/json", StringComparison.OrdinalIgnoreCase))
            {
                var res = _mapper.Map<IEnumerable<ProductVM>>(query.Take(8));
                return Json(res);
            }

            var vm = _mapper.Map<ShopVM>(shopQuery);

            vm.Categories = _unitOfWork.Category.GetAll().GroupJoin(
                _unitOfWork.Product.GetAll(),
                c => c.Id,
                p => p.CategoryId,
                (c, products) => new 
                CategoryWithCountVM
                {
                    Id = c.Id,
                    Name = c.Name,
                    ProductCount = products.Count()
                }).ToList();

            const int pageSize = 6;
            vm.Products = query.ToPagedList(shopQuery.PageNumber, pageSize);
            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var product = _unitOfWork.Product.GetOne(p => p.Id == id, "Category");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var shoppingCart = _unitOfWork.ShoppingCart.
                GetOne(x => x.ProductId == id && x.UserId == userId);
            ViewBag.Amount = (shoppingCart == null) ? 0 : shoppingCart.Amount;
            // return View(product);
            return View("~/Views/Errors/InProgress.cshtml");
        }
    }
}
