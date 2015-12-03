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
    public class SoldOrderController : ApiController
    {
        private ISoldOrderService _soldOrderService = new SoldOrderService();

        // GET api/SoldOrder/GetAllSoldOrders
        [Route("api/SoldOrder/GetAllSoldOrders")]
        public IQueryable GetOrders()
        {
            var rs = _soldOrderService.GetAllSoldOrders().OrderBy(o => o.CreateDate).Select(o => new {
                OrderID = o.ID,
                CustomerName = o.Customer.FullName,
                CreateDate = o.CreateDate,
                o.Address,
                o.Total,
                Status = o.Order_Status.Name,
            }).AsQueryable();
            return rs;
        }

        // GET api/SoldOrder/GetSoldOrderByID/{id}
        [Route("api/SoldOrder/GetSoldOrderByID/{id}")]
        [ResponseType(typeof(SoldOrder))]
        public IHttpActionResult GetSoldOrderByID(int id)
        {
            SoldOrder soldOrder = _soldOrderService.GetSoldOrderByID(id);
            if (soldOrder == null)
            {
                return NotFound();
            }
            //var statusString = _orderStatusService.GetOrderStatusByID(soldOrder.Status).Name;

            var result = new
            {
                ID = soldOrder.ID,
                CustomerID = soldOrder.CustomerID,
                CreateDate = String.Format("{0:d/M/yyyy HH:mm:ss}", soldOrder.CreateDate),
                Status = soldOrder.Order_Status.Name,
                Address = soldOrder.Address,
                Total = soldOrder.Total
            };

            return Ok(result);
        }

        // GET api/SoldOrder/GetSoldOrderForHistoryByID/{customerID}
        [Route("api/SoldOrder/GetSoldOrderForHistoryByID/{customerID}")]
        public IQueryable GetSoldOrderForHistoryByID(int customerID)
        {
            var rs = _soldOrderService.GetAllSoldOrders().AsEnumerable().Where(o => o.CustomerID == customerID).OrderBy(o => o.CreateDate).Select(o => new
            {
                o.ID,
                CreateDate = String.Format("{0:d/M/yyyy HH:mm:ss}", o.CreateDate),
                o.Total,
                o.Order_Status.Name
            }).AsQueryable();
            return rs;
        }

        [HttpGet]
        [Route("api/SoldOrder/CountNewSoldOrderAndInCome")]
        public IHttpActionResult CountNewSoldOrderAndInCome()
        {
            var newSoldOrder = _soldOrderService.CountNewSoldOrder();
            var income = _soldOrderService.CalcualteIncome();

            var result = new
            {
                NewSoldOrder = newSoldOrder,
                Income = income
            };

            return Ok(result);
        }

        [HttpGet]
        [Route("api/SoldOrder/GetMonthlyIncome")]
        public IQueryable GetMonthlyIncome()
        {
            return _soldOrderService.GetMonthlyIncome();
        }

        //[HttpPost]
        //[Route("api/SoldOrder/CreateSoldOrder")]
        //[ResponseType(typeof(SoldOrder))]
        //public IHttpActionResult PostCustomer([FromBody] SoldOrder soldOrder)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var success = _soldOrderService.AddSoldOrder(soldOrder);

        //    if (!success)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    return CreatedAtRoute("DefaultApi", new { id = soldOrder.ID }, soldOrder);
        //}
    }
}