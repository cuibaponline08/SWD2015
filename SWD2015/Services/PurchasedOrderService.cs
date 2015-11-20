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
    }
}