using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP_Homework_Product.Models;
using OnlineShop.Db;

namespace ASP_Homework_Product.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var products = _productRepository.GetProducts();
            var productsView = new List<ProductViewModel>();
            foreach(var product in products)
            {
                var productView = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description,
                    ImgLink = product.ImgLink
                };
                productsView.Add(productView);
            }
            return View(productsView);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
		public IActionResult SearchIndex(string searchInfo)
		{
            if(searchInfo != null)
            {
                var products = _productRepository?.SearchProduct(searchInfo);
                return View(products);
            }
            return RedirectToAction("Index");
		}
	}
}
