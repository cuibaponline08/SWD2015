using SWD2015.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Services
{
    public interface IProductStatusService
    {
        IQueryable<Product_Status> GetAllProductStatus();
        Product_Status GetProductStatustByID(int id);
        string GetProductStatustNameByID(int id);
        bool AddProductStatus(Product_Status productStatus);
        bool EditProductStatus(Product_Status productStatus);
        bool DeleteProductStatus(int productStatusID);
    }
}