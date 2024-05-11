using System;
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
	public class Order
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
        public string Date { get; }
        public string Time { get; }
        public OrderStatuses Status { get; set; }
        public Order()
        {
            Date = DateTime.Now.ToShortDateString();
            Time = DateTime.Now.ToShortTimeString();
            Status = OrderStatuses.Created;
        }
    }
}
