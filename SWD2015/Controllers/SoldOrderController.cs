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
    public class SoldOrderController : ApiController
    {
        private ISoldOrderService _soldOrderService = new SoldOrderService();

        // GET api/SoldOrder/GetAllSoldOrders
        [Route("api/SoldOrder/GetAllSoldOrders")]
        public IQueryable GetOrders()
        {
            var rs = _soldOrderService.GetAllSoldOrders().OrderBy(o => o.CreateDate).Select(o => new IConvertible[]{
                o.ID,
                o.CustomerID,
                o.CreateDate,
                o.Order_Status.Name,
                o.Address,
                o.Total
            }).AsQueryable();
            return rs;
        }

        // GET api/Order/GetOrderByID/{id}
        [Route("api/SoldOrder/GetSoldOrderByID/{id}")]
        [ResponseType(typeof(OrderPOCO))]
        public IHttpActionResult GetSoldOrderByID(int id)
        {
            SoldOrder soldOrder = _soldOrderService.GetSoldOrderByID(id);
            if (soldOrder == null)
            {
                return NotFound();
            }

            OrderPOCO poco = new OrderPOCO()
            {
                ID = soldOrder.ID,
                CustomerID = soldOrder.CustomerID,
                CreateDate = soldOrder.CreateDate,
                Status = soldOrder.Order_Status.Name,
                Address = soldOrder.Address,
                Total = soldOrder.Total
            };

            return Ok(poco);
        }

        // GET api/SoldOrder/GetSoldOrderForHistoryByID/{customerID}
        [Route("api/SoldOrder/GetSoldOrderForHistoryByID/{customerID}")]
        //[ResponseType(typeof(SoldOrder))]
        public IQueryable GetSoldOrderForHistoryByID(int customerID)
        {
            var rs = _soldOrderService.GetAllSoldOrders().Where(o => o.CustomerID == customerID).OrderBy(o => o.CreateDate).Select(o => new IConvertible[]{
                o.ID,
                o.CreateDate,
                o.Total,
                o.Order_Status.Name
            }).AsQueryable();
            return rs;
        }

        //// PUT api/Order/5
        //public IHttpActionResult PutOrder(int id, SoldOrder soldOrder)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != soldOrder.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _soldOrderService.UpdateSoldOrder(soldOrder);

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST api/Order
        //[ResponseType(typeof(SoldOrder))]
        //public IHttpActionResult PostOrder(SoldOrder soldOrder)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _soldOrderService.AddSoldOrder(soldOrder);

        //    return CreatedAtRoute("DefaultApi", new { id = soldOrder.ID }, soldOrder);
        //}

        //// DELETE api/Order/5
        //[ResponseType(typeof(SoldOrder))]
        //public IHttpActionResult DeleteOrder(int id)
        //{
        //    SoldOrder soldOrder = _soldOrderService.GetSoldOrderByID(id);
        //    if (soldOrder == null)
        //    {
        //        return NotFound();
        //    }

        //    _soldOrderService.DeleteSoldOrder(soldOrder);

        //    return Ok(soldOrder);
        //}
    }
}