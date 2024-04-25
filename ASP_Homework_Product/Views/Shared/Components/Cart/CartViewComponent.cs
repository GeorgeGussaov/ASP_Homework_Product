using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

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
            string cntProducts = cart?.Amount.ToString() ?? null;
            return View("Cart", cntProducts);
        }
    }
}
