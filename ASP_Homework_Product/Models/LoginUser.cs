using System;
using System.ComponentModel.DataAnnotations;

namespace ASP_Homework_Product.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Введите логин")]
        [EmailAddress(ErrorMessage = "Укажите email")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
        public bool CheckBox { get; set; }
        public Guid Id { get; }
        public LoginUser() { Id = Guid.NewGuid(); }
    }
}
