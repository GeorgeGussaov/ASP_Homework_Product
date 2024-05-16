using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
		public decimal Cost { get; set; }
		public string Description { get; set; }
        public string ImgLink { get; set; }
        public List<CartItem> CartItems { get; set; }
        public Product()
        {
            CartItems = new List<CartItem>();
        }
		public Product(string name, decimal cost, string description, string imgLink)
		{
			Id = Guid.NewGuid();
			Name = name;
			Cost = cost;
			Description = description;
			ImgLink = imgLink;
		}
	}
}
