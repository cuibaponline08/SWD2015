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

        // GET api/customer/GetCustomers
        [Route("api/customer/GetCustomers")]
        public IQueryable GetCustomers()
        {
            return _customerService.GetAllCustomers().Select(c => new CustomerPOCO(){
                FullName = c.FullName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                //Birthday = c.Birthday.HasValue ? c.Birthday.Value.ToString() : "unknown",
                Birthday = c.Birthday.Value,
                Gender = c.Gender,
                Address = c.Address,
                //c.isGuest == true ? "Guest": "Registered",
                ImageURL = c.ImageURL
            }).AsQueryable();
        }

        // GET api/Customer/
        [Route("api/customer/GetCustomerByID/{id}")]
        [ResponseType(typeof(CustomerPOCO))]
        public IHttpActionResult GetCustomerByID(int id)
        {
            Customer customer = _customerService.GetCustomerByID(id);
            if (customer == null)
            {
                return NotFound();
            }

            CustomerPOCO poco = new CustomerPOCO()
            {
                FullName = customer.FullName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Birthday = customer.Birthday,
                Gender = customer.Gender,
                Address = customer.Address,
                ImageURL = customer.ImageURL
            };

            return Ok(poco);
        }

        // PUT api/Customer/5
        //[Route("api/customer/GetCustomer/{id}")]
        [Route("api/customer/UpdateCustomerDetail/{id}")]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PutCustomer(int id, CustomerPOCO poco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer customer = _customerService.GetCustomerByID(id);
            if (customer == null)
            {
                return BadRequest();
            }

            customer.FullName = poco.FullName;
            customer.Email = poco.Email;
            customer.PhoneNumber = poco.PhoneNumber;
            customer.Birthday = poco.Birthday;
            customer.Gender = poco.Gender;
            customer.Address = poco.Address;
            customer.ImageURL = poco.ImageURL;

            _customerService.UpdateCustomer(customer);

            return Ok(customer);
        }

        //// POST api/Customer
        //[ResponseType(typeof(Customer))]
        //public IHttpActionResult PostCustomer(Customer customer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _customerService.AddCustomer(customer);

        //    return CreatedAtRoute("DefaultApi", new { id = customer.ID }, customer);
        //}

        //// DELETE api/Customer/5
        //[ResponseType(typeof(Customer))]
        //public IHttpActionResult DeleteCustomer(int id)
        //{
        //    Customer customer = _customerService.GetCustomerByID(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    _customerService.DeleteCustomer(customer);

        //    return Ok(customer);
        //}
    }
}