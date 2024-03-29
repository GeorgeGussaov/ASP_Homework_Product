using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ASP_Homework_Product.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        public AdminController(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Orders()
        {
            var orders = _orderRepository.GetOrders();
            return View(orders);
        }
		public IActionResult EditOrderStatus(int id)
		{
            var order = _orderRepository.GetOrders()[id]; 
			return View(order);
		}
		public IActionResult Users()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Products()
        {
            var products = _productRepository.GetProducts(); 

            return View(products);
        }

        [HttpPost]
        public IActionResult ChangeStatus(Guid id, OrderStatuses status)
        {
            var order = _orderRepository.TryGetById(id);
            order.Status = status;
            return RedirectToAction("Orders");
        }
    }
}
