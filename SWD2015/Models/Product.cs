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
    
    public partial class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public int Status { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int Amount { get; set; }
        public string ImageURL { get; set; }
        public Nullable<int> TotalSell { get; set; }
    }
}
