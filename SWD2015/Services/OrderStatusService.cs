using SWD2015.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private Infrastructure.IRepository<Order_Status> _orderStatusRepository = new Infrastructure.Repository<Order_Status>();

        public Models.Order_Status GetOrderStatusByID(int id)
        {
            return _orderStatusRepository.GetById(id);
        }
    }
}