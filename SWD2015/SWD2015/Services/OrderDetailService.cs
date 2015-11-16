using SWD2015.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private OrderDetailRepository _orderDetailRepository = new OrderDetailRepository();

        public IQueryable<Models.OrderDetail> GetAllOrderDetailsByOrderID(int orderID)
        {
            return _orderDetailRepository.GetMany(o => o.OrderID == orderID && o.IsDelete == false);
        }

        public Models.OrderDetail GetOrderDetailByID(int orderDetailID)
        {
            return _orderDetailRepository.GetById(orderDetailID);
        }

        public bool AddOrderDetail(Models.OrderDetail orderDetail)
        {
            try
            {
                _orderDetailRepository.Add(orderDetail);
                _orderDetailRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateOrderDetail(Models.OrderDetail orderDetail)
        {
            var od = _orderDetailRepository.GetById(orderDetail.ID);
            if (od != null)
            {
                _orderDetailRepository.Update(orderDetail);
                _orderDetailRepository.Save();
                return true;
            }
            return false;
        }

        public bool DeleteOrderDetail(Models.OrderDetail orderDetail)
        {
            var od = _orderDetailRepository.GetById(orderDetail.ID);
            if (od != null)
            {
                _orderDetailRepository.Delete(orderDetail);
                _orderDetailRepository.Save();
                return true;
            }
            return false;
        }
    }
}