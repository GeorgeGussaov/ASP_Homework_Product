using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Homework_Product.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConstants _Constants;
        public LoginController(IConstants constants)
        {
            _Constants = constants;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                var logUser = _Constants.LoginUser(user);
                if (logUser == null)
                {
                    ModelState.AddModelError("", "Введен неправильный логин или пароль");
                    return View("Index");
                }
                return View();
            }
			return View("Index");
        }
    }
}
