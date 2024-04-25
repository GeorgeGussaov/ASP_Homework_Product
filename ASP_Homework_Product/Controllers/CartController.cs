using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;
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
            return View(cart);
        }
        public IActionResult Add(int productId)
        {
            var product = _productRepository.GetProduct(productId);
            _cartRepository.Add(product, _constants.GetUserId());
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int productId)
        {
            var product = _productRepository.GetProduct(productId);
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
