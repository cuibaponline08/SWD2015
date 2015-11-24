using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Models.ViewModels
{
    public class NewProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Category { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
    }
}