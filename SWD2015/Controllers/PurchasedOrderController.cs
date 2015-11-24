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
using SWD2015.Models.ViewModels;

namespace SWD2015.Controllers
{
    public class PurchasedOrderController : ApiController
    {
        //private DB_9DFD26_SWD2015Entities db = new DB_9DFD26_SWD2015Entities();
        private Services.IPurchasedOrderService _purchasedOrderService = new Services.PurchasedOrderService();

        // GET api/PurchasedOrder
        public IQueryable GetPurchasedOrders()
        {
            var rs = _purchasedOrderService.GetAllPurchasedOrders().OrderBy(o => o.CreateDate).Select(o => new IConvertible[]{
                o.ID,
                o.CreateDate,
                o.Total,
                o.Order_Status.Name
            }).AsQueryable();
            return rs;
        }

        [Route("api/PurchasedOrder/GetAllPurchasedOrderDetailsByCustomerID/{customerID}")]
        public IQueryable GetAllPurchasedOrderDetailsByCustomerID(int customerID)
        {
            return _purchasedOrderService.GetAllPurchasedOrders().
                Where(o => o.CustomerID == customerID).OrderBy(o => o.CreateDate).Select(o => new HistoryOrderDetailViewModel(){
                OrderID = o.ID,
                ProductName = o.ProductName,
                CreateDate = o.CreateDate,
                Total = o.Total,
                OrderStatus = o.Order_Status.Name
            });
        }

        // GET api/PurchasedOrder/5
        [ResponseType(typeof(PurchasedOrder))]
        public IHttpActionResult GetPurchasedOrder(int id)
        {
            PurchasedOrder purchasedorder = _purchasedOrderService.GetPurchasedOrderByID(id);
            if (purchasedorder == null)
            {
                return NotFound();
            }

            return Ok(purchasedorder);
        }

        //// PUT api/PurchasedOrder/5
        //public IHttpActionResult PutPurchasedOrder(int id, PurchasedOrder purchasedorder)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != purchasedorder.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(purchasedorder).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PurchasedOrderExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST api/PurchasedOrder
        //[ResponseType(typeof(PurchasedOrder))]
        //public IHttpActionResult PostPurchasedOrder(PurchasedOrder purchasedorder)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.PurchasedOrders.Add(purchasedorder);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (PurchasedOrderExists(purchasedorder.ID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = purchasedorder.ID }, purchasedorder);
        //}

        //// DELETE api/PurchasedOrder/5
        //[ResponseType(typeof(PurchasedOrder))]
        //public IHttpActionResult DeletePurchasedOrder(int id)
        //{
        //    PurchasedOrder purchasedorder = db.PurchasedOrders.Find(id);
        //    if (purchasedorder == null)
        //    {
        //        return NotFound();
        //    }

        //    db.PurchasedOrders.Remove(purchasedorder);
        //    db.SaveChanges();

        //    return Ok(purchasedorder);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool PurchasedOrderExists(int id)
        //{
        //    return db.PurchasedOrders.Count(e => e.ID == id) > 0;
        //}
    }
}