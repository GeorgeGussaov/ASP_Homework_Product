using ASP_Homework_Product.Helpers;
using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using OnlineShop.Db;

namespace ASP_Homework_Product.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository _cartRepository;
        private readonly IConstants _constants;
        public CartViewComponent(ICartsRepository cartsRepository, IConstants constants)
        {
            _cartRepository = cartsRepository;
            _constants = constants;
        }

        public IViewComponentResult Invoke()
        {
            var cart = _cartRepository.TryGetByUId(_constants.GetUserId());
            var cartView = Mapping.ToCartViewModel(cart);
            string cntProducts = cartView?.Amount.ToString() ?? null;
            return View("Cart", cntProducts);
        }
    }
}
