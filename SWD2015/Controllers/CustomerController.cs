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

        /// <summary>
        /// Check that user had enter exact email and password or not
        /// </summary>
        /// <param name="email">Enter email</param>
        /// <param name="password">Enter password</param>
        /// <returns></returns>
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
        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns></returns>
        public IQueryable<Customer> GetCustomers()
        {
            return _customerService.GetAllCustomers().Select(c => new
                {
                    ID = c.ID,
                    FullName = c.FullName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    //Birthday = c.Birthday.HasValue ? c.Birthday.Value.ToString() : "unknown",
                    Birthday = c.Birthday.Value,
                    Gender = c.Gender,
                    Address = c.Address,
                    //c.isGuest == true ? "Guest": "Registered",
                    ImageURL = c.Image.ImageURL
                }).AsQueryable();
        }

       
        // GET api/Customer/
        /// <summary>
        /// Get one customer by ID if found 
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
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

            if (!success)
            {
                return NotFound();
            }

            _customerService.DeleteCustomer(customer);

            return Ok(customer);
        }
    }
}