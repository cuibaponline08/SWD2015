using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Models.POCOs
{
    public class ProductPOCO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public System.DateTime CreateDate { get; set; }
        public ICollection<Product_Image> ImageURL { get; set; }
        public string Status { get; set; }
    }
}