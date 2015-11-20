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
        SoldOrder GetSoldOrderByID(int soldOrderID);
        bool AddSoldOrder(SoldOrder soldOrder);
        bool UpdateSoldOrder(SoldOrder soldOrder);
        bool DeleteSoldOrder(SoldOrder soldOrder);
    }
}