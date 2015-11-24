using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Models.ViewModels
{
    public class HistoryOrderDetailViewModel
    {
        public int OrderID { get; set; }
        public string ProductName { get; set; }
        public DateTime CreateDate { get; set; }
        public double Total { get; set; }
        public string OrderStatus { get; set; }
    }
}