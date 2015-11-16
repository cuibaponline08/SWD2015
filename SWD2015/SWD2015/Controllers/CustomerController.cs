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
    public class CustomerController : ApiController
    {
        private ICustomerService _customerService = new CustomerService();

        [Route("api/Customer/CheckLogin/{email}/{password}")]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult CheckLogin(string email, string password)
        {
            //var rs = _customerService.GetCustomerByID(id);
            //string name = rs.FullName;
            Customer customer = _customerService.CheckLogin(email, password);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // GET api/Customer
        public IQueryable<Customer> GetCustomers()
        {
            var rs = _customerService.GetAllCustomers().ToList();

            return _customerService.GetAllCustomers();
        }

        // GET api/Customer/
        [Route("api/customer/GetCustomer/{id}")]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            //var rs = _customerService.GetCustomerByID(id);
            //string name = rs.FullName;
            Customer customer = _customerService.GetCustomerByID(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT api/Customer/5
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.ID)
            {
                return BadRequest();
            }

            _customerService.UpdateCustomer(customer);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Customer
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _customerService.AddCustomer(customer);

            return CreatedAtRoute("DefaultApi", new { id = customer.ID }, customer);
        }

        // DELETE api/Customer/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = _customerService.GetCustomerByID(id);
            if (customer == null)
            {
                return NotFound();
            }

            _customerService.DeleteCustomer(customer);

            return Ok(customer);
        }
    }
}