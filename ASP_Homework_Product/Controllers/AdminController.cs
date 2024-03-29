using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ASP_Homework_Product.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IRolesRepository _rolesRepository;
        public AdminController(IProductRepository productRepository, IOrderRepository orderRepository, IRolesRepository rolesRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _rolesRepository = rolesRepository;
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
            var roles = _rolesRepository.GetRoles();
            return View(roles);
        }
        public IActionResult AddRole()
        {
            return View();
        }
        public IActionResult DeleteRole(Guid id)
        {
            _rolesRepository.Delete(id);
            return RedirectToAction("Roles");
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
        public IActionResult SaveRole(string name)
        {
            var roles = _rolesRepository.GetRoles();
            if (roles.FirstOrDefault(r => r.Name == name) != null)
            {
				ModelState.AddModelError("", "Такая роль уже есть!");
			}
            if (ModelState.IsValid)
            {
                _rolesRepository.Add(new Role { Name = name });
                return RedirectToAction("Roles");
            }
            //return RedirectToAction("AddRole");
            return View("AddRole");
        }
    }
}
