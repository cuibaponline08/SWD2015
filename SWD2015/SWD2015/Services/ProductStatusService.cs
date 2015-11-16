using SWD2015.Infrastructure;
using SWD2015.Models;
using SWD2015.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Services
{
    public class ProductStatusService : IProductStatusService
    {
        private IRepository<Product_Status> _productStatusRepository = new ProductStatusRepository();

        public IQueryable<Product_Status> GetAllProductStatus()
        {
            var rs = _productStatusRepository.GetAll();
            return rs;
        }

        public Product_Status GetProductStatustByID(int id)
        {
            var rs = _productStatusRepository.GetById(id);
            return rs;
        }

        public bool AddProductStatus(Product_Status productStatus)
        {
            try
            {
                _productStatusRepository.Add(productStatus);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditProductStatus(Product_Status productStatus)
        {
            var pS = _productStatusRepository.GetById(productStatus.ID);
            if (pS != null)
            {
                _productStatusRepository.Update(productStatus);
                return true;
            }
            return false;
        }

        public bool DeleteProductStatus(int productStatusID)
        {
            var pS = _productStatusRepository.GetById(productStatusID);
            if (pS != null)
            {
                _productStatusRepository.Delete(pS);
                return true;
            }
            return false;
        }
    }
}