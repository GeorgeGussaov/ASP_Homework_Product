using ASP_Homework_Product.Helpers;
using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace ASP_Homework_Product.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartsRepository _cartRepository;
        private readonly IConstants _constants;
        private readonly IOrderRepository _orderRepository;
        public OrderController(IProductRepository productRepository, ICartsRepository cartRepository, IConstants constants, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
            _constants = constants;
            _orderRepository = orderRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Buy(Order order)
        {
            if(ModelState.IsValid)
            {
				var cart = _cartRepository.TryGetByUId(_constants.GetUserId());
				order.Cart = Mapping.ToCartViewModel(cart);
				_orderRepository.Add(order);
				_cartRepository.Clear(_constants.GetUserId());
				return View(order);
			}
            return View("Index");
        }
    }
}
