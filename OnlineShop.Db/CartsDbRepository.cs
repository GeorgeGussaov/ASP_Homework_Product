using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace OnlineShop.Db
{
    public class CartsDbRepository : ICartsRepository
    {
        private readonly DatabaseContext _databaseContext;
        public CartsDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        //private List<Cart> Carts = new List<Cart>();

        public Cart TryGetByUId(Guid userId)
        {
            return _databaseContext.Carts.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
        }
        public void Add(Product product, Guid userId)
        {
            var CartIsExist = TryGetByUId(userId);
            if(CartIsExist == null)
            {
                Cart newCart = new Cart()
                {
                    UserId = userId,
                };
                newCart.CartItems = new List<CartItem>()
                {
                    new CartItem() {
                        Product = product,
                        Amount = 1,
                        //Cart=newCart
                    }
                };
                _databaseContext.Carts.Update(newCart);
            }
            else
            {
                CartItem CartItemIsExist = CartIsExist.CartItems.FirstOrDefault(pr => pr.Product.Id == product.Id);
                if (CartItemIsExist == null)
                {
                    CartIsExist.CartItems.Add(new CartItem()
                    {
                        Product = product,
                        Amount = 1,
                        //Cart=CartIsExist
                    });
                }
                else
                    CartItemIsExist.Amount++;
            }
            _databaseContext.SaveChanges();
        }

        public void Delete(Product product, Guid userId)
        {
            var Cart = TryGetByUId(userId);
            CartItem CartItem = Cart.CartItems.FirstOrDefault(pr => pr.Product.Id == product.Id);
            if(CartItem.Amount > 1) CartItem.Amount--;
            else Cart.CartItems.Remove(CartItem);
            _databaseContext.SaveChanges();
        }

        public void Clear(Guid userId)
        {
            var Cart = TryGetByUId(userId);
            _databaseContext.Carts.Remove(Cart);
            _databaseContext.SaveChanges();
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
