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
using SWD2015.Repositories;
using SWD2015.Infrastructure;
using SWD2015.Services;

namespace SWD2015.Controllers
{
    public class ProductStatusController : ApiController
    {
        private IProductStatusService _productStatusService = new ProductStatusService();

        // GET api/ProductStatus
        public IQueryable<Product_Status> GetProduct_Status()
        {
            return _productStatusService.GetAllProductStatus();
        }

        // GET api/ProductStatus/5
        [ResponseType(typeof(Product_Status))]
        public IHttpActionResult GetProduct_Status(int id)
        {
            Product_Status product_status = _productStatusService.GetProductStatustByID(id);
            if (product_status == null)
            {
                return NotFound();
            }
            return Ok(product_status);
        }
    }
}