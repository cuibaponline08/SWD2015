using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using SWD2015.Models;

namespace SWD2015.Controllers
{
    public class PurchasedOrderController : ApiController
    {
        private readonly Services.IPurchasedOrderService _purchasedOrderService = new Services.PurchasedOrderService();

        // GET api/PurchasedOrder
        /// <summary>
        /// API for GET all Purchased Orders in CMS and Android
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/PurchasedOrder/GetAllPurchasedOrders")]
        public IQueryable GetPurchasedOrders()
        {
            var rs = _purchasedOrderService.GetAllPurchasedOrders().OrderBy(o => o.CreateDate).Select(o => new {
                o.ID,
                o.ProductName,
                CustomerName = o.Customer.FullName,
                CreateDate = o.CreateDate,
                o.Address,
                o.Total,
                OrderStatus = o.Order_Status.Name
            }).AsQueryable();
            return rs;
        }

        [HttpGet]
        [Route("api/PurchasedOrder/SearchPurchasedOrders/{keywords}")]
        public IQueryable SearchPurchasedOrders(string keywords)
        {
            var rs = _purchasedOrderService.GetAllPurchasedOrders().Where(po => po.Customer.FullName.Contains(keywords)).OrderBy(o => o.CreateDate).Select(o => new
            {
                o.ID,
                o.ProductName,
                CustomerName = o.Customer.FullName,
                o.CreateDate,
                o.Address,
                o.Total,
                OrderStatus = o.Order_Status.Name
            }).AsQueryable();
            return rs;
        }

        [HttpGet]
        [Route("api/PurchasedOrder/GetAllPurchasedOrderDetailsByCustomerID/{customerID}")]
        public IQueryable GetAllPurchasedOrderDetailsByCustomerID(int customerID)
        {
            return _purchasedOrderService.GetAllPurchasedOrders().AsEnumerable().
                Where(o => o.CustomerID == customerID).OrderBy(o => o.CreateDate).Select(o => new {
                OrderID = o.ID,
                o.ProductName,
                CreateDate = String.Format("{0:d/M/yyyy HH:mm:ss}", o.CreateDate),
                o.Total,
                OrderStatus = o.Order_Status.Name
            }).AsQueryable();
        }

        [HttpGet]
        [Route("api/PurchasedOrder/CountPurchasedProduct")]
        public IQueryable CountPurchasedProduct()
        {
            return _purchasedOrderService.CountPurchasedProduct();
        }

        [HttpGet]
        [Route("api/PurchasedOrder/CountNewPurchasedOrderAndInventory")]
        public IHttpActionResult CountNewPurchasedOrderAndInventory()
        {
            var newPurchasedOrder = _purchasedOrderService.CountNewPurchasedOrder();
            var inventory = _purchasedOrderService.CalculateInventory();

            var result = new {
                NewPurchasedOrder = newPurchasedOrder,
                Inventory = inventory
            };

            return Ok(result);
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

            var result = new
            {
                purchasedorder.ID,
                CustomerName = purchasedorder.Customer.FullName,
                EmployeeName = purchasedorder.Employee.Name,
                purchasedorder.CustomerID,
                purchasedorder.EmployeeID,
                purchasedorder.CreateDate,
                OrderStatus = purchasedorder.Order_Status.Name,
                Status = purchasedorder.OrderStatus,
                purchasedorder.Address,
                purchasedorder.Total,
                purchasedorder.ProductName,
                purchasedorder.Description,
                purchasedorder.Product_Category.CategoryName,
                CategoryID = purchasedorder.Category
            };

            return Ok(result);
        }

        // POST api/PurchasedOrder
        [Route("api/PurchasedOrder/AddPurchasedOrder")]
        [ResponseType(typeof(PurchasedOrder))]
        public IHttpActionResult PostPurchasedOrder(PurchasedOrder purchasedorder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = _purchasedOrderService.AddPurchasedOrder(purchasedorder);

            if (!success)
            {
                return BadRequest(ModelState);
            }

            return CreatedAtRoute("DefaultApi", new { id = purchasedorder.ID }, purchasedorder);
        }

        [HttpGet]
        [Route("api/PurchasedOrder/GetMonthlyInventory")]
        public IQueryable GetMonthlyInventory()
        {
            return _purchasedOrderService.GetMonthlyInventory();
        }

        // PUT api/PurchasedOrder/UpdatePurchasedOrder?id=4
        [Route("api/PurchasedOrder/UpdatePurchasedOrder")]
        public IHttpActionResult PutPurchasedOrder(int id, PurchasedOrder purchasedOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchasedOrder.ID)
            {
                return BadRequest();
            }

            try
            {
                var result = _purchasedOrderService.UpdatePurchasedOrder(purchasedOrder);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}