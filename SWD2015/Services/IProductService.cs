﻿using SWD2015.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD2015.Services
{
    public interface IProductService
    {
        IQueryable<Product> GetAllProducts();
        Product GetProductByID(int id);
        IQueryable<Product> GetByProductID(int id);
        bool AddProduct(Product product);
        bool EditProduct(Product product);
        bool DeleteProduct(Product product);
        IQueryable<Product> GetNewProducts();
        IQueryable<Product> GetHotProducts();
        IQueryable<Product> SearchProduct(string keywords, int categoryID);
    }
}
