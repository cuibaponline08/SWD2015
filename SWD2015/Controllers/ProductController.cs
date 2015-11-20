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

namespace SWD2015.Controllers
{
    public class ProductController : ApiController
    {
        private DB_9DFD26_SWD2015Entities db = new DB_9DFD26_SWD2015Entities();
        private IProductService _productService = new ProductService();
        //private IProductStatusService _productStatusService = new ProductStatusService();

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
        public IQueryable<ProductPOCO> GetProducts()
        {
            return _productService.GetAllProducts().Select(p => new ProductPOCO()
            {
                ID = p.ID,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                CategoryName = p.Product_Category.Name,
                CreateDate = p.CreateDate,
                ImageURL = p.ImageURL,
                Status = "Có hàng" //TODO: at this time, just status = 2 is available
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

        // GET api/Product/5
        [ResponseType(typeof(ProductPOCO))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = _productService.GetProductByID(id);

            if (product == null)
            {
                return NotFound();
            }

            ProductPOCO poco = new ProductPOCO()
            {
                ID = product.ID,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryName = product.Product_Category.Name,
                CreateDate = product.CreateDate,
                ImageURL = product.ImageURL,
                Status = product.Stocks.Where(s => s.Status == DataFactory.AVAILABLEPRODUCT).FirstOrDefault().Product_Status.Name //TODO: at this time, just status = 1 is available
            };

            return Ok(poco);
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