using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
                var users = _Constants.GetUsers();
                if (users.FirstOrDefault(u => user.Login == u.Login) != null) //если такой логин уже имеется среди других, т.е. такой пользователь уже зареган
                {
                    ModelState.AddModelError("", "Такая почта уже зарегистрирована!");
                    return View("Index");
                }
                else
                {
                    LoginUser newUser = new LoginUser() { Login = user.Login, Password = user.Password, Name = user.Name};
                    _Constants.RegisterUser(newUser);
                }
                return View(user);
            }
            if (user.Login == user.Password) ModelState.AddModelError("", "Логин и пароль не должны совподать");
            return View("Index");
        }
    }
}
