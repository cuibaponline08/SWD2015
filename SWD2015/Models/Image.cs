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
    
    public partial class Image
    {
        public Image()
        {
            this.Customers = new HashSet<Customer>();
            this.Product_Image = new HashSet<Product_Image>();
            this.PurchasedOrder_Image = new HashSet<PurchasedOrder_Image>();
        }
    
        public int ID { get; set; }
        public int AlbumID { get; set; }
        public string ImageURL { get; set; }
    
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Product_Image> Product_Image { get; set; }
        public virtual ICollection<PurchasedOrder_Image> PurchasedOrder_Image { get; set; }
    }
}
