using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Db
{
    public class WishlistsDbRepository : IWishlistRepository
    {
        private readonly DatabaseContext _dbContext;
        public WishlistsDbRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Wishlist TryGetByUId(Guid userId)
        {
            return _dbContext.Wishlists.Include(x => x.WishListItems).FirstOrDefault(x => x.UserId == userId);
        }
        public void Add(Product product, Guid userId)
        {
            var listIsExist = TryGetByUId(userId);
            if(listIsExist == null)
            {
                Wishlist wishlist = new Wishlist()
                {
                    UserId = userId,
                    WishListItems = new List<Product>() { product }
                };
                _dbContext.Wishlists.Add(wishlist);
            }
            else listIsExist.WishListItems.Add(product);
            _dbContext.SaveChanges();
        }
        public void Delete(Product product, Guid userId)
        {
            var list = TryGetByUId(userId);
            list.WishListItems.Remove(product);
            _dbContext.SaveChanges();
        }
    }

    public interface IWishlistRepository
    {
        public Wishlist TryGetByUId(Guid userId);
        void Add(Product product, Guid userId);
        public void Delete(Product product, Guid userId);
    }
}
