using SWD2015.Infrastructure;
using SWD2015.Models;
using SWD2015.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Services
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository = new OrderRepository();
        public IQueryable<Models.Order> GetAllOrders()
        {
            var rs = _orderRepository.GetAll();
            return rs;
        }

        public Models.Order GetOrderByID(int orderID)
        {
            var order = _orderRepository.GetById(orderID);
            return order;
        }

        public bool AddOrder(Models.Order order)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrder(Models.Order order)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrder(Models.Order order)
        {
            throw new NotImplementedException();
        }
    }
}