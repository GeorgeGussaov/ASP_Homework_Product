using ASP_Homework_Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP_Homework_Product
{
    public class InMemoryOrdersRepository : IOrderRepository
    {
        private List<Order> Orders = new List<Order>();
        public List<Order> GetOrders() { return Orders; }
        public void Add(Order order)
        {
            Orders.Add(order);
        }

        public Order TryGetById(Guid id)
        {
            return Orders.FirstOrDefault(o => o.OrderId == id);
        }
    }

    public interface IOrderRepository
    {
        public List<Order> GetOrders();
        public void Add(Order order);
        public Order TryGetById(Guid id);


    }
}
