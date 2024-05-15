using ASP_Homework_Product.Models;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using System.Collections.Generic;

namespace ASP_Homework_Product.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(List<Product> products)
        {
            var productViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                ProductViewModel productView = new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description,
                    ImgLink = product.ImgLink,
                };
                productViewModels.Add(productView);
            }
            return productViewModels;
        }
        public static ProductViewModel ToProductViewModel(Product product)
        {
            ProductViewModel productViewModel = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImgLink = product.ImgLink,
            };
            return productViewModel;
        }
        public static Product ToProductDb(ProductViewModel productView)
        {
            Product product = new Product()
            {
                Id = productView.Id,
                Name = productView.Name,
                Cost = productView.Cost,
                Description = productView.Description,
                ImgLink = productView.ImgLink
            };
            return product;
        }







        public static List<CartItemViewModel> ToCartItemsViewModel(List<CartItem> cartItems)
        {
            var cartItemViewModels = new List<CartItemViewModel>();
            foreach (var item in cartItems)
            {
                CartItemViewModel cartItemView = new CartItemViewModel()
                {
                    Id = item.Id,
                    Amount = item.Amount,
                    Product = ToProductViewModel(item.Product)
                };
                cartItemViewModels.Add(cartItemView);
            }
            return cartItemViewModels;
        }

		public static List<CartItem> ToCartItemsDb(List<CartItemViewModel> cartItemViewModels)
		{
			var cartItems = new List<CartItem>();
			foreach (var item in cartItemViewModels)
			{
				CartItem cartItem = new CartItem()
				{
					Id = item.Id,
					Amount = item.Amount,
					Product = ToProductDb(item.Product)
				};
				cartItems.Add(cartItem);
			}
			return cartItems;
		}
		public static CartViewModel ToCartViewModel(Cart cart)
        {
            if(cart == null) return null;
            return new CartViewModel()
            {
                Id = cart.Id,
                UserId = cart.UserId,
                CartItems = ToCartItemsViewModel(cart.CartItems)
            };
        }
		public static Cart ToCartDb(CartViewModel cart)
		{
			if (cart == null) return null;
			return new Cart()
			{
				Id = cart.Id,
				UserId = cart.UserId,
				CartItems = ToCartItemsDb(cart.CartItems)
			};
		}






		public static WishlistViewModel ToWishlistViewModel(Wishlist wishlist)
        {
            if(wishlist == null) return null;
            var viewModel = new WishlistViewModel()
            {
                UserId = wishlist.UserId,
                Id = wishlist.Id,
                WishListItems = ToProductViewModels(wishlist.WishListItems)
            };
            return viewModel;
        }







        public static Order ToOrderDb(OrderViewModel orderView)
        {
			var orderDb = new Order()
			{

				OrderId = orderView.OrderId,
				Name = orderView.Name,
				Email = orderView.Email,
				Address = orderView.Address,
                CartItems = ToCartItemsDb(orderView.Cart.CartItems),
                //Cart = Mapping.ToCartDb(orderView.Cart),
                Date = orderView.Date,
				Time = orderView.Time,
				Status = (OnlineShop.Db.Models.OrderStatuses)orderView.Status
			};
            return orderDb;
		}
        public static OrderViewModel ToOrderViewModel(Order order)
        {
			var orderView = new OrderViewModel()
			{

				OrderId = order.OrderId,
				Name = order.Name,
				Email = order.Email,
				Address = order.Address,
                //CartItems = ToCartItemsViewModel(order.CartItems),
                //Cart = Mapping.ToCartViewModel(order.Cart),
                Cart = new CartViewModel() { CartItems = ToCartItemsViewModel(order.CartItems) },
                Date = order.Date,
				Time = order.Time,
				Status = (Models.OrderStatuses)order.Status
			};
			return orderView;
		}
        public static List<OrderViewModel> ToOrdersViewModel(List<Order> orders)
        {
            List<OrderViewModel> ordersView = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                ordersView.Add(ToOrderViewModel(order));
            }
            return ordersView;
        }
    }
}
