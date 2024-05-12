using ASP_Homework_Product.Helpers;
using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using System;

namespace ASP_Homework_Product.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index(Guid id)
        {
            //ProductRepository catalog = new ProductRepository();
            Product product = _productRepository.GetProductById(id);
            return View(Mapping.ToProductViewModel(product));
        }
		public IActionResult Edit(Guid id)
		{
			Product product = _productRepository.GetProductById(id);
            
            return View(Mapping.ToProductViewModel(product));
        }

		public IActionResult Add()
		{
			return View();
		}

		public IActionResult Delete(Guid id)
		{
			_productRepository.Delete(id);
            return Redirect("/admin/admin/products");
		}


		[HttpPost]
		public IActionResult ChangeProductInfo(Guid id, ProductViewModel product)
		{
			if (ModelState.IsValid)
			{
				_productRepository.ChangeProduct(id, product.Name, product.Cost, product.Description);
				//return RedirectToAction("Products", "Admin");
				return Redirect("/admin/admin/products");
				
			}
			return View("Edit");
		}

		[HttpPost]
		public IActionResult NewProduct(ProductViewModel product)
		{
			if(ModelState.IsValid)
			{
				Product newProduct = new Product() { Name = product.Name,
				Cost = product.Cost,
				Description = product.Description, ImgLink = "#"}; //этот продукст создается чтобы инициализировать unicId.
																										//Если передать product, то при переходе на стр товара выводится первый товар
				_productRepository.Add(newProduct);
                return Redirect("/admin/admin/products");
            }
			return View("Add");
		}
	}
}
