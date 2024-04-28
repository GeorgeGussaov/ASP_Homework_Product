using System;
using System.ComponentModel.DataAnnotations;

namespace ASP_Homework_Product.Models
{
    public class LoginUser
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Введите логин")]
        [EmailAddress(ErrorMessage = "Укажите email")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
        public bool CheckBox { get; set; }
        [Required(ErrorMessage ="Укажите имя")]
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}
