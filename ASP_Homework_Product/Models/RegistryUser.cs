using System.ComponentModel.DataAnnotations;

namespace ASP_Homework_Product.Models
{
    public class RegistryUser
    {
        [Required(ErrorMessage ="Введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите логин")]
        [EmailAddress(ErrorMessage = "Укажите корректный email")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Пароль должен быть от 4 до 20 символов")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string RepeatPassword { get; set; }
    }
}
