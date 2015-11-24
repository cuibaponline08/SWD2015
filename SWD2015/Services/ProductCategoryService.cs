using SWD2015.Infrastructure;
using SWD2015.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private IRepository<Product_Category> _productCategoryRepository = new Repositories.ProductCategoryRepository();
        public Models.Product_Category GetProductCategoryByID(int id)
        {
            return _productCategoryRepository.GetById(id);
        }
    }
}