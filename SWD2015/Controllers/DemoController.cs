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

namespace SWD2015.Controllers
{
    public class DemoController : ApiController
    {
        private DB_9DFD26_SWD2015Entities db = new DB_9DFD26_SWD2015Entities();

        // GET api/Demo
        public IQueryable<Order_Status> GetOrder_Status()
        {
            return db.Order_Status;
        }

        // GET api/Demo/5
        [ResponseType(typeof(Order_Status))]
        public IHttpActionResult GetOrder_Status(int id)
        {
            Order_Status order_status = db.Order_Status.Find(id);
            if (order_status == null)
            {
                return NotFound();
            }

            return Ok(order_status);
        }

        // PUT api/Demo/5
        public IHttpActionResult PutOrder_Status(int id, Order_Status order_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order_status.ID)
            {
                return BadRequest();
            }

            db.Entry(order_status).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Order_StatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Demo
        [ResponseType(typeof(Order_Status))]
        public IHttpActionResult PostOrder_Status(Order_Status order_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Order_Status.Add(order_status);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Order_StatusExists(order_status.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = order_status.ID }, order_status);
        }

        // DELETE api/Demo/5
        [ResponseType(typeof(Order_Status))]
        public IHttpActionResult DeleteOrder_Status(int id)
        {
            Order_Status order_status = db.Order_Status.Find(id);
            if (order_status == null)
            {
                return NotFound();
            }

            db.Order_Status.Remove(order_status);
            db.SaveChanges();

            return Ok(order_status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Order_StatusExists(int id)
        {
            return db.Order_Status.Count(e => e.ID == id) > 0;
        }
    }
}