using SWD2015.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD2015.Services
{
    public interface IOrderDetailService
    {
        IQueryable<Models.OrderDetail> GetAllActivedOrderDetails();
        IQueryable<OrderDetail> GetAllOrderDetailsByOrderID(int orderID);
        IQueryable<OrderDetail> GetAllSoldOrdersByCustomerID(int customerID);
        OrderDetail GetOrderDetailByID(int orderDetailID);
        bool AddOrderDetail(OrderDetail orderDetail);
        bool UpdateOrderDetail(OrderDetail orderDetail);
        bool DeleteOrderDetail(OrderDetail orderDetail);
        IQueryable CountSoldProduct();
    }
}
