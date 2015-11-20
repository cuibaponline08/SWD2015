using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Models.POCOs
{
    public class OrderPOCO
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public double Total { get; set; }
    }
}