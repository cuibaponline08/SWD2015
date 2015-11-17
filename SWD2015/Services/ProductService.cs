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
        IRepository<Order> _orderRepository = new OrderRepository();

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

        // Get List Products have just added since 14 days
        // p.Status == 1, means this product is available
        public IQueryable<Product> GetNewProducts()
        {
            return _productRepository.GetMany(p => p.Status == 1 && (DateTime.Now.Date - p.CreateDate.Date).Days <= 14);
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
            return _productRepository.GetMany(p => p.Status == 1 
                //&& _orderRepository.Get(o => (DateTime.Now - o.CreateDate).Days <= 30) != null
                ).OrderByDescending(p => p.TotalSell);
        }
    }
}