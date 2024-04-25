using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Homework_Product.Controllers
{
    public class RegistryController : Controller
    {
        private readonly IConstants _Constants;
        public RegistryController(IConstants constants)
        {
            _Constants = constants;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter(RegistryUser user)
        {
            if (ModelState.IsValid)
            {
                LoginUser newUser = new LoginUser() { Login= user.Login, Password = user.Password};
                _Constants.RegisterUser(newUser);
                return View(user);
            }
            if (user.Login == user.Password) ModelState.AddModelError("", "Логин и пароль не должны совподать");
            return RedirectToAction("Index");
        }
    }
}
