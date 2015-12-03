using SWD2015.Infrastructure;
using SWD2015.Models;
using SWD2015.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private IRepository<OrderDetail> _orderDetailRepository = new OrderDetailRepository();
        private IRepository<SoldOrder> _soldOrderRepository = new SoldOrderRepository();

        public IQueryable<Models.OrderDetail> GetAllOrderDetailsByOrderID(int orderID)
        {
            return _orderDetailRepository.GetMany(o => o.SoldOrderID == orderID && o.IsDelete == false);
        }

        public IQueryable<OrderDetail> GetAllActivedOrderDetails()
        {
            return _orderDetailRepository.GetMany(od => od.SoldOrder.Status == DataFactory.SOLD_ORDER_STATUS_ID);
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
                _orderDetailRepository.Update(od);
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
                _orderDetailRepository.Delete(od);
                _orderDetailRepository.Save();
                return true;
            }
            return false;
        }

        public IQueryable<Models.OrderDetail> GetAllSoldOrdersByCustomerID(int customerID)
        {
            //var listOrder = _soldOrderRepository.GetMany(o => o.CustomerID == customerID);
            return _orderDetailRepository.GetMany(od => od.SoldOrder.CustomerID == customerID);
        }


        public IQueryable CountSoldProduct()
        {
            var rs = _orderDetailRepository.GetAll().Where(od => od.SoldOrder.Status == DataFactory.SOLD_ORDER_STATUS_ID).GroupBy(od => od.Product.Product_Category.Product_Category2.ID).Select(group => new
            {
                SuperCategory = group.Key,
                Count = group.Count()
            }).OrderBy(x => x.SuperCategory);

            return rs;
        }
    }
}