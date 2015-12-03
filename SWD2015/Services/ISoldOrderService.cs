using SWD2015.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Services
{
    public interface ISoldOrderService
    {
        IQueryable<SoldOrder> GetAllSoldOrders();
        IQueryable GetMonthlyIncome();
        SoldOrder GetSoldOrderByID(int soldOrderID);
        SoldOrder AddSoldOrder(SoldOrder soldOrder);
        bool UpdateSoldOrder(SoldOrder soldOrder);
        bool DeleteSoldOrder(SoldOrder soldOrder);
        int CountNewSoldOrder();
        double CalcualteIncome();
    }
}