using SWD2015.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD2015.Services
{
    public interface IPurchasedOrderService
    {
        IQueryable<PurchasedOrder> GetAllPurchasedOrders();
        PurchasedOrder GetPurchasedOrderByID(int purchasedOrderID);
        IQueryable CountPurchasedProduct();
        int CountNewPurchasedOrder();
        double CalculateInventory();
        bool AddPurchasedOrder(PurchasedOrder purchasedOrder);
        PurchasedOrder UpdatePurchasedOrder(PurchasedOrder purchasedOrder);
        IQueryable GetMonthlyInventory();

    }
}
