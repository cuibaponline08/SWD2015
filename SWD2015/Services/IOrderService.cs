using SWD2015.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Services
{
    public interface IOrderService
    {
        IQueryable<Order> GetAllOrders();
        Order GetOrderByID(int orderID);
        bool AddOrder(Order order);
        bool UpdateOrder(Order order);
        bool DeleteOrder(Order order);
    }
}