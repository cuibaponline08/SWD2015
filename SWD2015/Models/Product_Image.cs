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
    
    public partial class Product_Image
    {
        public int ID { get; set; }
        public int ImageID { get; set; }
        public int ProductID { get; set; }
    
        public virtual Image Image { get; set; }
    }
}
