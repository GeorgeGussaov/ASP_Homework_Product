using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP_Homework_Product.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<CartItem> CartItems { get; set; }
        public decimal Cost
        {
            get { return CartItems.Sum(c => c.Cost); }
        }
        public int Amount
        {
            get { return CartItems?.Sum(c => c.Amount) ?? 0; }
        }
    }

}
