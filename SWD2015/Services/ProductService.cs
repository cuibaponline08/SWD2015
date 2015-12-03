using SWD2015.Infrastructure;
using SWD2015.Models;
using SWD2015.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SWD2015.Services
{
    public class ProductService : IProductService
    {
        IRepository<Product> _productRepository = new ProductRepository();
        IRepository<OrderDetail> _orderDetailRepository = new OrderDetailRepository();

        public IQueryable<Models.Product> GetAllProducts()
        {
            //GET all product amount > 0 and Available to sales
            return _productRepository.GetMany(p => p.Stocks.Where(s => s.Status == DataFactory.AVAILABLE_PRODUCT && s.Amount > 0).FirstOrDefault() != null);
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

        // Get List Products have just added since 14 days
        // p.Status == 1, means this product is available
        public IQueryable<Product> GetNewProducts()
        {
            //return _productRepository.GetMany(p => (DateTime.Now.Date - p.CreateDate.Date).Days <= 14);
            DateTime today = new DateTime();
            today = DateTime.Now.Date;
            return _productRepository.GetMany(p => DbFunctions.
                DiffDays(today, p.CreateDate) <= DataFactory.DAYS_FOR_NEW_PRODUCT &&
                p.Stocks.Where(s => s.Amount > 0 && s.Status == DataFactory.AVAILABLE_PRODUCT).FirstOrDefault() != null).
                OrderByDescending(p => p.CreateDate).Take(15);
        }
        // Get List Hot Products in 30 days
        public IQueryable<Product> GetHotProducts()
        {
            DateTime today = new DateTime();
            today = DateTime.Now.Date;
            var listProductID = _orderDetailRepository.GetMany(od => DbFunctions.
                DiffDays(today, od.SoldOrder.CreateDate) <= DataFactory.DAYS_FOR_HOT_PRODUCT &&
                od.Product.Stocks.Where(s => s.Amount > 0 && s.Status == 1).FirstOrDefault() != null).
                Take(15).Select(od => od.ProductID).ToList();

            return _productRepository.GetMany(p => listProductID.Contains(p.ID));
        }

        // Private
        private int GetTotalProductSold(int productID)
        {
            return _orderDetailRepository.GetMany(od => od.ProductID == productID).Sum(od => od.Quantity);
        }

        public bool EditProduct(Product product)
        {
            var p = _productRepository.GetById(product.ID);
            if (p != null)
            {
                _productRepository.Update(p);
                _productRepository.Save();
                return true;
            }
            return false;
        }

        public bool DeleteProduct(Product product)
        {
            var p = _productRepository.GetById(product.ID);
            if (p != null)
            {
                _productRepository.Delete(p);
                _productRepository.Save();
                return true;
            }
            return false;
        }


        public IQueryable<Product> GetByProductID(int id)
        {
            return _productRepository.GetMany(p => p.ID == id);
        }


        public IQueryable<Product> SearchProduct(string keywords, int categoryID)
        {
            IQueryable<Product> rs;
            List<int> superCategory = new List<int> { 1, 6, 10, 14, 18, 21, 25 };
            if (categoryID == 0)
            {
                rs = _productRepository.GetMany(p => p.Name.Contains(keywords) && p.Stocks.Where(s => s.Amount > 0 && s.Status == 1).FirstOrDefault() != null);
            }
            else if (superCategory.Contains(categoryID))
            {
                rs = _productRepository.GetMany(p => p.Product_Category.Product_Category2.ID == categoryID && p.Name.Contains(keywords) && p.Stocks.Where(s => s.Amount > 0 && s.Status == 1).FirstOrDefault() != null);
            }
            else
            {
                rs = _productRepository.GetMany(p => p.Category == categoryID && p.Name.Contains(keywords) && p.Stocks.Where(s => s.Amount > 0 && s.Status == 1).FirstOrDefault() != null);
            }

            return rs;
        }
    }
}