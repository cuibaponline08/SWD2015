//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SWD2015.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool isGuest { get; set; }
        public int ImageID { get; set; }
    
        public virtual Image Image { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}