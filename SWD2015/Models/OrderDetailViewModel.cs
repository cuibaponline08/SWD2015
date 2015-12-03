using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Models
{
    public class OrderDetailViewModel
    {
        //public string AA { get; set; }
        public Customer Customer { get; set; }
        //public OrderDetail OrderDetail { get; set; }
        public List<OrderDetail> ListOrderDetail { get; set; }
    }
}