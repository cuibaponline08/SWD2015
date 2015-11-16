using SWD2015.Infrastructure;
using SWD2015.Models;
using SWD2015.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Services
{
    public class ProductService : IProductService
    {
        IRepository<Product> _productRepository = new ProductRepository();

        public IQueryable<Models.Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Models.Product GetProductByID(int id)
        {
            return _productRepository.GetById(id);
        }


        public bool AddProduct(Product product)
        {
            try
            {
                _productRepository.Add(product);
                _productRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public IQueryable<Product> GetNewProducts()
        {
            //return _productRepository.GetMany(p => (DateTime.Now.Subtract(p.CreateDate).Duration(30));
            return null;
        }
    }
}