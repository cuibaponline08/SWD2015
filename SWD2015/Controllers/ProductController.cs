using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SWD2015.Models;
using SWD2015.Services;

namespace SWD2015.Controllers
{
    public class ProductController : ApiController
    {
        private IProductService _productService = new ProductService();
        
        [Route("api/product/GetHotProducts/")]
        public IQueryable GetHotProducts()
        {
            return _productService.GetHotProducts().Select(p => new
            {
                ProductID = p.ID,
                ProductName = p.Name,
                ProductPrice = p.Price,
                CategoryName = p.Product_Category.CategoryName,
                ImageURL = p.Product_Image.Select(pp => pp.Image.ImageURL),
            }).AsQueryable();
        }

        // GET api/Product
        public IQueryable GetProducts()
        {
            return _productService.GetAllProducts().Select(p => new
            {
                ProductID = p.ID,
                ProductName = p.Name,
                ProductPrice = p.Price,
                CategoryName = p.Product_Category.CategoryName,
                ImageURL = p.Product_Image.Select(pp => pp.Image.ImageURL),
            }).AsQueryable();
        }

        [Route("api/product/GetNewProducts")]
        public IQueryable GetNewProducts()
        {
            // amount must be > than 0
            return _productService.GetNewProducts().Take(15).Select(p => new
            {
                ProductID = p.ID,
                ProductName = p.Name,
                ProductPrice = p.Price,
                CategoryName = p.Product_Category.CategoryName,
                ImageURL = p.Product_Image.Select(pp => pp.Image.ImageURL),
            }).AsQueryable();
        }

        [HttpGet]
        [Route("api/product/SearchProduct/{keywords}/{categoryID}")]
        public IQueryable SearchProduct(string keywords, int categoryID)
        {
            return _productService.SearchProduct(keywords, categoryID).Select(p => new
            {
                ProductID = p.ID,
                ProductName = p.Name,
                ProductPrice = p.Price,
                CategoryID = p.Product_Category.ID,
                ImageURL = p.Product_Image.Select(pp => pp.Image.ImageURL),
            }).AsQueryable();
        }

        [HttpGet]
        [Route("api/product/SearchProduct/{categoryID}")]
        public IQueryable SearchProductByCategory(int categoryID)
        {
            string keywords = "";
            return _productService.SearchProduct(keywords, categoryID).Select(p => new
            {
                ProductID = p.ID,
                ProductName = p.Name,
                ProductPrice = p.Price,
                CategoryID = p.Product_Category.ID,
                ImageURL = p.Product_Image.Select(pp => pp.Image.ImageURL),
            }).AsQueryable();
        }

        // GET api/Product/5
        [Route("api/product/GetProductByID/{id}")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = _productService.GetProductByID(id);

            if (product == null)
            {
                return NotFound();
            }

            var result = new
            {
                ProductID = product.ID,
                ProductName = product.Name,
                ProductPrice = product.Price,
                ProductDescription = product.Description,
                CategoryID = product.Category,
                CreateDate = String.Format("{0:d/M/yyyy HH:mm:ss}", product.CreateDate),
                ImageURL = product.Product_Image.Select(p => p.Image.ImageURL),
                Status = product.Stocks.Where(s=>s.Amount > 0 && s.Status == DataFactory.AVAILABLE_PRODUCT).FirstOrDefault().Product_Status.Name
            };
            
            return Ok(result);
        }
    }
}