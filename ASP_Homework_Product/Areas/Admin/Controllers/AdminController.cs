using ASP_Homework_Product.Helpers;
using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP_Homework_Product.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly IConstants _constants;
        public AdminController(IProductRepository productRepository, IOrderRepository orderRepository, IRolesRepository rolesRepository, IConstants constants)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _rolesRepository = rolesRepository;
            _constants = constants;
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
            return View(_constants.GetUsers());
        }
        public IActionResult UserPage(Guid id)
        {
            var user = _constants.GetUserById(id);
            return View(user);
        }
        public IActionResult AddUserForm()
        {
            return View();
        }
        public IActionResult ChangeUserDataForm(Guid id)
        {
            var user = _constants.GetUserById(id);
            return View(user);
        }
        public IActionResult ChangeUserPassForm(Guid id)
        {
            var user = _constants.GetUserById(id);
            return View(user);
        }
        public IActionResult ChangeUserRoleForm(Guid id)
        {
            var user = _constants.GetUserById(id);

            return View(user);
        }
        public IActionResult DeleteUser(Guid id)
        {
            _constants.DeleteUser(id);
            return RedirectToAction("Users");
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
            //var productsView = new List<ProductViewModel>();
            //foreach (var product in products)
            //{
            //    var productView = new ProductViewModel
            //    {
            //        Id = product.Id,
            //        Name = product.Name,
            //        Cost = product.Cost,
            //        Description = product.Description,
            //        ImgLink = product.ImgLink
            //    };
            //    productsView.Add(productView);
            //}
            return View(Mapping.ToProductViewModels(products));
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

        public IActionResult AddUser(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                _constants.RegisterUser(user);
                return RedirectToAction("Users");
            }
            return View("AddUserForm");
        }
        [HttpPost]
        public IActionResult ChangeUserData(LoginUser user)
        {
            _constants.ChangeUserDataInfo(user.Id, user.Name, user.Login);
            return RedirectToAction("Users");
            
        }
        public IActionResult ChangeUserPass(LoginUser user)
        {
            _constants.ChangeUserPass(user.Id, user.Password);
            return RedirectToAction("Users");
        }

        public IActionResult ChangeUserRole(LoginUser user)
        {
            if (!_rolesRepository.CheckRole(user.Role.Name))
            {
                ModelState.AddModelError("", "Такой роли не существует");
                return View("ChangeUserRoleForm");
            }
            _constants.ChangeUserRole(user.Id, user.Role.Name);
            return RedirectToAction("Users");
        }

    }
}
