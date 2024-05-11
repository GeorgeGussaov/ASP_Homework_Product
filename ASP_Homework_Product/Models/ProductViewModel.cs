using System;
using System.ComponentModel.DataAnnotations;

namespace ASP_Homework_Product.Models
{
    public class ProductViewModel
    {
        private static int unicId;
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Введите название")]
        public string Name { get; set; }
		[Required(ErrorMessage = "Введите цену")]
		public decimal Cost { get; set; }
		[Required(ErrorMessage = "Введите описание")]
		public string Description { get; set; }
        public string ImgLink;
        //public Product(string name, decimal cost, string description, string imgLink)
        //{
        //    Name = name;
        //    Cost = cost;
        //    Description = description;
        //    Id = unicId++;
        //    ImgLink = imgLink;
        //}
        //public Product()
        //{

        //}

        //public override string ToString()
        //{
        //    return $"{Id}\n{Name}\n{Cost}\n";
        //}

    }
}
