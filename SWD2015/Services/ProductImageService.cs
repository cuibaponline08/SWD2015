using SWD2015.Infrastructure;
using SWD2015.Models;
using SWD2015.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Services
{
    public class ProductImageService : IProductImageService
    {
        private IRepository<Product_Image> _productImageRepository = new ProductImageRepository();
        public IQueryable<Product_Image> GetProductImagesByProductID(int productID)
        {
            return _productImageRepository.GetMany(pi => pi.ProductID == productID);
        }
    }
}