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
using SWD2015.Models.POCOs;
using SWD2015.Models.ViewModels;

namespace SWD2015.Controllers
{
    public class ProductController : ApiController
    {
        //private DB_9DFD26_SWD2015Entities db = new DB_9DFD26_SWD2015Entities();
        private IProductService _productService = new ProductService();
        private IProductImageService _productImageService = new ProductImageService();
        private IImageService _imageService = new ImageService();
        private IProductCategoryService _productCategoryService = new ProductCategoryService();
        private IStockService _stockService = new StockService();
        private IProductStatusService _productStatusService = new ProductStatusService();

        [Route("api/product/GetFavouriteProducts/")]
        public IQueryable<Product> GetFavouriteProducts()
        {
            var rs = _productService.GetFavouriteProducts();
            if (rs != null)
            {
                return rs;
            }
            return null;
        }

        // GET api/Product
        public IQueryable GetProducts()
        {
            return _productService.GetAllProducts().Select(p => new
            {
                ID = p.ID,
                Name = p.Name,
                Price = p.Price,
                CategoryName = p.Product_Category.CategoryName,
                ImageURL = p.Product_Image.FirstOrDefault().Image.ImageURL,
                //TODO: at this time, just status = 2 is available
            }).AsQueryable();
        }

        //public IQueryable<ProductPOCO> GetFavouriteProducts()
        //{
        //    var rs = _productService.GetFavouriteProducts().Select(p => new ProductPOCO()
        //    {
        //        ID = p.ID,
        //        Name = p.Name,
        //        Price = p.Price,
        //        Description = p.Description,
        //        CategoryName = p.Product_Category.Name,
        //        CreateDate = p.CreateDate,
        //        ImageURL = p.ImageURL,
        //        Status = p.Stocks.Where(s => s.Status == DataFactory.AVAILABLEPRODUCT).FirstOrDefault().Product_Status.Name //TODO: at this time, just status = 1 is available
        //    }).AsQueryable();

        //    return rs;
        //}

        [Route("api/product/GetNewProducts")]
        public IQueryable GetNewProducts()
        {
            // amount must be > than 0
            return _productService.GetNewProducts().Take(15).Select(p => new
            {
                ID = p.ID,
                Name = p.Name,
                Price = p.Price,
                CategoryName = p.Product_Category.CategoryName,
                ImageURL = p.Product_Image.FirstOrDefault().Image.ImageURL,
            }).AsQueryable();
        }

        [HttpGet]
        [Route("api/product/SearchProduct/{keywords}/{categoryID}")]
        public IQueryable SearchProduct(string keywords, int categoryID)
        {
            return _productService.SearchProduct(keywords, categoryID).Select(p => new
            {
                ID = p.ID,
                Name = p.Name,
                Price = p.Price,
                //Description = p.Description,
                CategoryName = p.Product_Category.CategoryName,
                //CreateDate = p.CreateDate,
                ImageURL = p.Product_Image.FirstOrDefault().Image.ImageURL,
                //Status = p.Stocks //TODO: at this time, just status = 2 is available
            }).AsQueryable();
        }

        // GET api/Product/5
        [Route("api/product/GetProductByID/{id}")]
        //[ResponseType(typeof(ProductPOCO))]
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
                ProductDescription = product.Description,
                CategoryID = product.Category,
                CreateDate = product.CreateDate,
                ImageURL = product.Product_Image.Select(p => new { p.Image.ImageURL }),
                Status = product.Stocks.Where(s=>s.Amount > 0 && s.Status == DataFactory.AVAILABLE_PRODUCT).FirstOrDefault().Product_Status.Name
            };
            
            return Ok(result);
        }

        //TODO: must be continue implement these methods below:

        //// PUT api/Product/5
        //public IHttpActionResult PutProduct(int id, Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != product.ID)
        //    {
        //        return BadRequest();
        //    }


        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST api/Product
        //[ResponseType(typeof(Product))]
        //public IHttpActionResult PostProduct(Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Products.Add(product);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = product.ID }, product);
        //}

        //// DELETE api/Product/5
        //[ResponseType(typeof(Product))]
        //public IHttpActionResult DeleteProduct(int id)
        //{
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Products.Remove(product);
        //    db.SaveChanges();

        //    return Ok(product);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ProductExists(int id)
        //{
        //    return db.Products.Count(e => e.ID == id) > 0;
        //}
    }
}