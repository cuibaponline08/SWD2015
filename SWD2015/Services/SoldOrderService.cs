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
        private IRepository<SoldOrder> _soldOrderRepository = new SoldOrderRepository();
        public IQueryable<Models.SoldOrder> GetAllSoldOrders()
        {
            var rs = _soldOrderRepository.GetAll().Where(so => so.Status >= 0);
            return rs;
        }

        public Models.SoldOrder GetSoldOrderByID(int soldOrderID)
        {
            var SoldOrder = _soldOrderRepository.GetById(soldOrderID);
            _soldOrderRepository.Save();
            return SoldOrder;
        }

        public SoldOrder AddSoldOrder(SoldOrder soldOrder)
        {
            try
            {
                _soldOrderRepository.Add(soldOrder);
                _soldOrderRepository.Save();

                var newSoldOrder = _soldOrderRepository.GetDatabaseValues(soldOrder);
                return newSoldOrder;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateSoldOrder(Models.SoldOrder soldOrder)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSoldOrder(Models.SoldOrder soldOrder)
        {
            throw new NotImplementedException();
        }


        public int CountNewSoldOrder()
        {
            return _soldOrderRepository.GetMany(so => so.Status == DataFactory.NEW_SOLD_ORDER_STATUS_ID).Count();
        }

        public double CalcualteIncome()
        {
            return _soldOrderRepository.GetMany(so => so.Status == DataFactory.SOLD_ORDER_STATUS_ID && so.CreateDate.Year == 2015).Sum(so => so.Total);
        }

        public IQueryable GetMonthlyIncome()
        {
            return _soldOrderRepository.GetMany(so => so.Status == DataFactory.SOLD_ORDER_STATUS_ID && so.CreateDate.Year == 2015).GroupBy(so => so.CreateDate.Month).
                Select(group => new
                {
                    //Month = group.Key,
                    Money = group.Sum(so => so.Total),
                });
        }
    }
}