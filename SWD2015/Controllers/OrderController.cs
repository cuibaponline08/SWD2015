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
    public class OrderController : ApiController
    {
        private IOrderService _orderService = new OrderService();

        // GET api/Order
        public IQueryable<Order> GetOrders()
        {
            return _orderService.GetAllOrders();
        }

        // GET api/Order/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult GetOrder(int id)
        {
            Order order = _orderService.GetOrderByID(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT api/Order/5
        public IHttpActionResult PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.ID)
            {
                return BadRequest();
            }

            _orderService.UpdateOrder(order);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Order
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _orderService.AddOrder(order);

            return CreatedAtRoute("DefaultApi", new { id = order.ID }, order);
        }

        // DELETE api/Order/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrder(int id)
        {
            Order order = _orderService.GetOrderByID(id);
            if (order == null)
            {
                return NotFound();
            }

            _orderService.DeleteOrder(order);

            return Ok(order);
        }
    }
}