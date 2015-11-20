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
    public class OrderDetailController : ApiController
    {
        private IOrderDetailService _oderDetailService = new OrderDetailService();

        // GET api/OrderDetail
        public IQueryable<OrderDetail> GetAllOrderDetails()
        {
            // TODO
            return _oderDetailService.GetAllOrderDetailsByOrderID(1);
        }

        // GET api/OrderDetail/5
        [ResponseType(typeof(OrderDetail))]
        public IHttpActionResult GetOrderDetailByID(int id)
        {
            OrderDetail orderdetail = _oderDetailService.GetOrderDetailByID(id);
            if (orderdetail == null)
            {
                return NotFound();
            }

            return Ok(orderdetail);
        }

        // GET api/OrderDetail
        // GET All Order Detail by its OrderID
        //public IQueryable<OrderDetail> GetAllAvailableOrderDetailsByOrderID(int orderID)
        //{
        //    return _oderDetailService.GetAllOrderDetailsByOrderID(orderID);
        //}

        //// PUT api/OrderDetail/5
        //public IHttpActionResult PutOrderDetail(int id, OrderDetail orderdetail)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != orderdetail.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _oderDetailService.UpdateOrderDetail(orderdetail);

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST api/OrderDetail
        //[ResponseType(typeof(OrderDetail))]
        //public IHttpActionResult PostOrderDetail(OrderDetail orderdetail)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _oderDetailService.AddOrderDetail(orderdetail);

        //    return CreatedAtRoute("DefaultApi", new { id = orderdetail.ID }, orderdetail);
        //}

        //// DELETE api/OrderDetail/5
        //[ResponseType(typeof(OrderDetail))]
        //public IHttpActionResult DeleteOrderDetail(int id)
        //{
        //    OrderDetail orderdetail = _oderDetailService.GetOrderDetailByID(id);
        //    if (orderdetail == null)
        //    {
        //        return NotFound();
        //    }

        //    _oderDetailService.DeleteOrderDetail(orderdetail);

        //    return Ok(orderdetail);
        //}
    }
}