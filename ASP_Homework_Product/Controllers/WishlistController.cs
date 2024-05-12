using ASP_Homework_Product.Helpers;
using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace ASP_Homework_Product.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IConstants _constants;
        private readonly IProductRepository _productRepository;
        public WishlistController(IWishlistRepository wishlistRepository, IConstants constants, IProductRepository productRepository)
        {
            _wishlistRepository = wishlistRepository;
            _constants = constants;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var wishlist = _wishlistRepository.TryGetByUId(_constants.GetUserId());
            return View(Mapping.ToWishlistViewModel(wishlist));
        }
        public IActionResult Add(Guid productId)
        {
            var product = _productRepository.GetProductById(productId);
            _wishlistRepository.Add(product, _constants.GetUserId());
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid productId)
        {
			var product = _productRepository.GetProductById(productId);
			_wishlistRepository.Delete(product, _constants.GetUserId());
			return RedirectToAction("Index");
		}
    }
}
