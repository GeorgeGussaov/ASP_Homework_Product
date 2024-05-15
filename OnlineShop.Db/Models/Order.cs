using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
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
        public string Name { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
        //public Cart Cart { get; set; }
        public string Date { get; set; }
        public string Time { get; set;}
        public OrderStatuses Status { get; set; }
        public List<CartItem> CartItems { get; set; }
        public Order()
        {
            Date = DateTime.Now.ToShortDateString();
            Time = DateTime.Now.ToShortTimeString();
            Status = OrderStatuses.Created;
        }
    }
}
