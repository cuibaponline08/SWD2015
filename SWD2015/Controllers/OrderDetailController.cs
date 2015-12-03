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
        private ICustomerService _customerService = new CustomerService();
        private ISoldOrderService _soldOrderService = new SoldOrderService();

        // GET api/OrderDetail
        [Route("api/OrderDetail/GetAllOrderDetailsByOrderID/{orderID}")]
        public IQueryable<OrderDetail> GetAllOrderDetailsByOrderID(int orderID)
        {
            // TODO
            return _oderDetailService.GetAllOrderDetailsByOrderID(orderID);
        }

        // PUT api/OrderDetail/5
        public IHttpActionResult PutOrderDetail(int id, OrderDetail orderdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderdetail.ID)
            {
                return BadRequest();
            }

            _oderDetailService.UpdateOrderDetail(orderdetail);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/OrderDetail
        [ResponseType(typeof(OrderDetail))]
        public IHttpActionResult PostOrderDetail(OrderDetail orderdetail)
        {
            return _oderDetailService.GetAllSoldOrdersByCustomerID(customerID).Select(od => new
            {
                OrderID = od.SoldOrderID,
                ProductName = od.Product.Name,
                CreateDate = od.SoldOrder.CreateDate,
                Total = od.SoldOrder.Total,
                OrderStatus = od.SoldOrder.Order_Status.Name,
            });
        }

        // DELETE api/OrderDetail/5
        [ResponseType(typeof(OrderDetail))]
        public IHttpActionResult DeleteOrderDetail(int id)
        {
            OrderDetail orderdetail = _oderDetailService.GetOrderDetailByID(id);
            if (orderdetail == null)
            {
                return NotFound();
            }

            _oderDetailService.DeleteOrderDetail(orderdetail);

            return Ok(orderdetail);
        }

        // GET api/OrderDetail/CountSoldProduct
        [HttpGet]
        [Route("api/OrderDetail/CountSoldProduct")]
        public IQueryable CountSoldProduct()
        {
            return _oderDetailService.CountSoldProduct();
        }
    }
}