using ASP_Homework_Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ASP_Homework_Product
{
    public class InMemoryCartsRepository : ICartsRepository
    {
        private List<Cart> Carts = new List<Cart>();
        public Cart TryGetByUId(Guid userId)
        {
            return Carts.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Product product, Guid userId)
        {
            var CartIsExist = TryGetByUId(userId);
            if(CartIsExist == null)
            {
                Cart newCart = new Cart()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    CartItems = new List<CartItem>
                    {
                        new CartItem() {
                            Id = Guid.NewGuid(),
                            Product = product,
                            Amount = 1
                        }
                    }
                };
                Carts.Add(newCart);
            }
            else
            {
                CartItem CartItemIsExist = CartIsExist.CartItems.FirstOrDefault(pr => pr.Product.Id == product.Id);
                if (CartItemIsExist == null)
                {
                    CartIsExist.CartItems.Add(new CartItem()
                    {
                        Id = Guid.NewGuid(),
                        Product = product,
                        Amount = 1
                    });
                }
                else
                    CartItemIsExist.Amount++;
            }
        }

        public void Delete(Product product, Guid userId)
        {
            var Cart = TryGetByUId(userId);
            CartItem CartItem = Cart.CartItems.FirstOrDefault(pr => pr.Product.Id == product.Id);
            if(CartItem.Amount > 1) CartItem.Amount--;
            else Cart.CartItems.Remove(CartItem);
        }

        public void Clear(Guid userId)
        {
            var Cart = TryGetByUId(userId);
            Carts.Remove(Cart);
        }

    }

    public interface ICartsRepository
    {
        public Cart TryGetByUId(Guid userId);
        public void Add(Product product, Guid userId);
        public void Delete(Product product, Guid userId);
        public void Clear(Guid userId);

    }
}
