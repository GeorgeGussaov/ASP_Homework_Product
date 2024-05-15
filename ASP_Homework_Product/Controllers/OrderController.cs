using ASP_Homework_Product.Helpers;
using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using System;

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
        public IActionResult Buy(OrderViewModel order)
        {
            if(ModelState.IsValid)
            {
				var cart = _cartRepository.TryGetByUId(_constants.GetUserId());
                //order.Cart = Mapping.ToCartViewModel(cart);
                var orderdb = new Order()
                {
                    Time = order.Time,
                    Date = order.Date,
                    Address = order.Address,
                    OrderId = order.OrderId,
                    Status = (OnlineShop.Db.Models.OrderStatuses)order.Status,  //3 дня я провозился с проблемой конфликтов id CartItems.
                    Email = order.Email,                                        //Зато лучше понял зависимости и навсегда запомнил что нельзя маппить айди от ViewModel.
					Name = order.Name,
                    CartItems = cart.CartItems
                };
                _orderRepository.Add(/*Mapping.ToOrderDb(order)*/ orderdb);
				_cartRepository.Clear(_constants.GetUserId());
				return View(order);
			}
            return View("Index");
        }
    }
}
