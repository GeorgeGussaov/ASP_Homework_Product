using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP_Homework_Product.Models
{
	public enum OrderStatuses
	{
		Created,
		Delivering,
		Delivered,
		Canceled
	}
	public class OrderViewModel
    {
        public Guid OrderId { get; set; }
        [Required(ErrorMessage = "Укажите имя")]
        public string Name { get; set; }
		[Required(ErrorMessage = "Укажите email")]
        [EmailAddress(ErrorMessage = "Укажите валидный email")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Укажите Адрес")]
		public string Address { get; set; }
        public CartViewModel Cart { get; set; }
        //public List<CartItemViewModel> CartItems { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public OrderStatuses Status { get; set; }
        public OrderViewModel()
        {
            Date = DateTime.Now.ToShortDateString();
            Time = DateTime.Now.ToShortTimeString();
            Status = OrderStatuses.Created;
        }
    }
}
