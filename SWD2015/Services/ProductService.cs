using SWD2015.Infrastructure;
using SWD2015.Models;
using SWD2015.Models.POCOs;
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
            return _productRepository.GetMany(p => DbFunctions.DiffDays(today, p.CreateDate) <= DataFactory.DAYS_FOR_NEW_PRODUCT).
                OrderByDescending(p => p.CreateDate).Take(15); //TODO: Product's amount msut be > 0
        }

        // Get List favourite Products in 30 days
        public IQueryable<Product> GetFavouriteProducts()
        {
            //var rs = _orderDetailRepository.GetMany(od => (DateTime.Now.Date - od.Order.CreateDate.Date).Days <= 30);
            //return _productRepository.GetMany(p => p.Status == 1 && _orderRepository.Get(o => (DateTime.Now.Date - o.CreateDate.Date).Days <= 30) != null).OrderByDescending(p => p.Count);
            //var aaa = _orderRepository.GetAll().FirstOrDefault().CreateDate;
            //var rs = _orderRepository.GetMany(o => DateTime.Now.Date < o.CreateDate || DateTime.Now.Date >= o.CreateDate).ToList();
            //var rs = _orderRepository.GetMany(o => (DateTime.Now - o.CreateDate).Days <= 100000000).ToList();
            //var rs = _orderRepository.Get
            //return _productRepository.GetMany(p => p.Status == 1
            //    && _orderRepository.Get(o => (DateTime.Now - o.CreateDate).Days <= 30) != null
            //    ).OrderByDescending(p => p.TotalSell);
            //var oderDetail = _orderDetailRepository.GetAll().OrderByDescending(od => od.Quantity);
            //var product = _productRepository.Get
            return _productRepository.GetAll();
        }

        // Private
        private int GetTotalProductSold(int productID)
        {
            return _orderDetailRepository.GetMany(od => od.ProductID == productID).Sum(od => od.Quantity);
        }

        public bool EditProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }


        public IQueryable<Product> GetByProductID(int id)
        {
            return _productRepository.GetMany(p => p.ID == id);
        }


        public IQueryable<Product> SearchProduct(string keywords, int categoryID)
        {
            return _productRepository.GetMany(p => p.Category == categoryID && p.Name.Contains(keywords));
        }
    }
}