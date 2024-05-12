using ASP_Homework_Product.Helpers;
using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using System;
using System.Linq;
namespace ASP_Homework_Product.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartsRepository _cartRepository;
        private readonly IConstants _constants;
        public CartController(IProductRepository productRepository, ICartsRepository cartRepository, IConstants constants)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
            _constants = constants;
        }
        public IActionResult Index()
        {
            var cart = _cartRepository.TryGetByUId(_constants.GetUserId());
            
            return View(Mapping.ToCartViewModel(cart));
        }
        public IActionResult Add(Guid productId)
        {
            Product product = _productRepository.GetProductById(productId);
            //ProductViewModel productView = new ProductViewModel()
            //{
            //    Id = productId,
            //    Name = product.Name,
            //    Cost = product.Cost,
            //    Description = product.Description,
            //    ImgLink = product.ImgLink,
            //};
            _cartRepository.Add(product, _constants.GetUserId());
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid productId)
        {
            var product = _productRepository.GetProductById(productId);
            //ProductViewModel productView = new ProductViewModel()
            //{
            //    Id= productId,
            //    Name = product.Name,
            //    Cost = product.Cost,
            //    Description = product.Description,
            //    ImgLink = product.ImgLink,
            //};
            _cartRepository.Delete(product, _constants.GetUserId());
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            _cartRepository.Clear(_constants.GetUserId());
            return RedirectToAction("Index");
        }
    }
}
