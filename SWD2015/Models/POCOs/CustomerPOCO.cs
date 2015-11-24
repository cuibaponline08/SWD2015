using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Models.POCOs
{
    public class CustomerPOCO
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ImageURL { get; set; }
    }
}