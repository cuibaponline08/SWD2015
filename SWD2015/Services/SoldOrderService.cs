using SWD2015.Infrastructure;
using SWD2015.Models;
using SWD2015.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Services
{
    public class SoldOrderService : ISoldOrderService
    {
        private IRepository<SoldOrder> _SoldOrderRepository = new SoldOrderRepository();
        public IQueryable<Models.SoldOrder> GetAllSoldOrders()
        {
            var rs = _SoldOrderRepository.GetAll().Where(so => so.Status >= 0);
            return rs;
        }

        public Models.SoldOrder GetSoldOrderByID(int soldOrderID)
        {
            var SoldOrder = _SoldOrderRepository.GetById(soldOrderID);
            _SoldOrderRepository.Save();
            return SoldOrder;
        }

        public bool AddSoldOrder(Models.SoldOrder soldOrder)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSoldOrder(Models.SoldOrder soldOrder)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSoldOrder(Models.SoldOrder soldOrder)
        {
            throw new NotImplementedException();
        }
    }
}