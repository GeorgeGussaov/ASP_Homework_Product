using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Homework_Product.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index(int id)
        {
            //ProductRepository catalog = new ProductRepository();
            Product product = _productRepository.GetProduct(id);
            return View(product);
        }
		public IActionResult Edit(int id)
		{
			Product product = _productRepository.GetProduct(id);
			return View(product);
		}

		public IActionResult Add()
		{
			return View();
		}

		public IActionResult Delete(int id)
		{
			_productRepository.Delete(id);
			//return RedirectToAction("Products", "Admin");
			return Redirect("/admin/admin/products");
		}


		[HttpPost]
		public IActionResult ChangeProductInfo(int id, Product product)
		{
			if (ModelState.IsValid)
			{
				_productRepository.ChangeProduct(id, product.Name, product.Cost, product.Description);
				//return RedirectToAction("Products", "Admin");
				return Redirect("/admin/admin/products");
				
			}
			return RedirectToAction("Edit");
		}

		[HttpPost]
		public IActionResult NewProduct(Product product)
		{
			if(ModelState.IsValid)
			{
				Product newProduct = new Product(product.Name, product.Cost, product.Description, "#"); //этот продукст создается чтобы инициализировать unicId.
																										//Если передать product, то при переходе на стр товара выводится первый товар
				_productRepository.Add(newProduct);
                //return RedirectToAction("Products", "Admin");
                return Redirect("/admin/admin/products");
            }
			return RedirectToAction("Add");
		}
	}
}
