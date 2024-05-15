using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ASP_Homework_Product
{
    public class OrdersDbRepository : IOrderRepository
    {
        private readonly DatabaseContext _databaseContext;
        public OrdersDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public List<Order> GetOrders() { return _databaseContext.Orders.Include(x => x.CartItems).ThenInclude(x=>x.Product).ToList(); }
        public void Add(Order order)
        {
            //_databaseContext.Entry(_databaseContext.Carts).State = EntityState.Detached;
            //_databaseContext.SaveChanges();
            _databaseContext.Orders.Update(order);
            _databaseContext.SaveChanges();
        }

        public Order TryGetById(Guid id)
        {
            return _databaseContext.Orders.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(o => o.OrderId == id);
        
        }
        public void ChangeStatus(Guid id, OrderStatuses statuse)
        {
            var order = TryGetById(id);
            order.Status = statuse;
            _databaseContext.SaveChanges();
        }
    }

    public interface IOrderRepository
    {
        public List<Order> GetOrders();
        public void Add(Order order);
        public Order TryGetById(Guid id);
        public void ChangeStatus(Guid id, OrderStatuses statuse);


	}
}
