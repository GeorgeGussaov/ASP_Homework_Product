using System.Collections.Generic;
using System;

namespace OnlineShop.Db.Models
{
    public class Wishlist
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<Product> WishListItems { get; set; }

    }
}
