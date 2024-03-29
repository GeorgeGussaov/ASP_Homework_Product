using System;
using System.ComponentModel.DataAnnotations;

namespace ASP_Homework_Product.Models
{
    public class Role
    {
        [Required(ErrorMessage ="Введите название роли.")]

        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}
