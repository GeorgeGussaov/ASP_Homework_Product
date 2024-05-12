using System.Collections.Generic;
using System;
using System.Linq;

namespace ASP_Homework_Product.Models
{
    public class WishlistViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<ProductViewModel> WishListItems { get; set; }
        
    }
}
