using SWD2015.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Services
{
    public class PurchasedOrderService : IPurchasedOrderService
    {
        private Infrastructure.IRepository<PurchasedOrder> _purchasedOderRepository = new Repositories.PurchasedOrderRepository();

        public IQueryable<Models.PurchasedOrder> GetAllPurchasedOrders()
        {
            return _purchasedOderRepository.GetAll();
        }

        public Models.PurchasedOrder GetPurchasedOrderByID(int purchasedOrderID)
        {
            return _purchasedOderRepository.GetById(purchasedOrderID);
        }

        public IQueryable CountPurchasedProduct()
        {
            var rs = _purchasedOderRepository.GetAll().Where(po => po.OrderStatus == DataFactory.PURCHASED_ORDER_STATUS_ID).GroupBy(po => po.Category).Select(group => new
            {
                SuperCategory = group.Key,
                Count = group.Count()
            }).OrderBy(x => x.SuperCategory);

            return rs;
        }

        public bool AddPurchasedOrder(PurchasedOrder purchasedOrder)
        {
            try
            {
                _purchasedOderRepository.Add(purchasedOrder);
                _purchasedOderRepository.Save();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public PurchasedOrder UpdatePurchasedOrder(PurchasedOrder purchasedOrder)
        {
            try
            {
                _purchasedOderRepository.Update(purchasedOrder);
                _purchasedOderRepository.Save();

                return _purchasedOderRepository.GetDatabaseValues(purchasedOrder);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int CountNewPurchasedOrder()
        {
            return _purchasedOderRepository.GetMany(po => po.OrderStatus == DataFactory.NEW_PURCHASED_ORDER_STATUS_ID).Count();
        }

        public double CalculateInventory()
        {
            return _purchasedOderRepository.GetMany(po => po.OrderStatus == DataFactory.PURCHASED_ORDER_STATUS_ID && po.CreateDate.Year == 2015).Sum(po => po.Total);
        }


        public IQueryable GetMonthlyInventory()
        {
            return _purchasedOderRepository.GetMany(po => po.OrderStatus == DataFactory.PURCHASED_ORDER_STATUS_ID && po.CreateDate.Year == 2015).GroupBy(po => po.CreateDate.Month).
                Select(group => new
                {
                    //Month = group.Key,
                    Money = group.Sum(po => po.Total),
                });
        }
    }
}