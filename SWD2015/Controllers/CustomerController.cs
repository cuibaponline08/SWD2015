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
        private IImageService _imageService = new ImageService();

        [Route("api/Customer/CheckLogin/{email}/{password}")]
        [ResponseType(typeof(CustomerPOCO))]
        public IHttpActionResult CheckLogin(string email, string password)
        {
            Customer customer = _customerService.CheckLogin(email, password);
            if (customer == null)
            {
                return NotFound();
            }

            //var stringURL = "";
            //if (customer.ImageID != null)
            //{
            //    var image = _imageService.GetImageByID(customer.ImageID.Value);
            //    if (image != null)
            //    {
            //        stringURL = image.ImageURL;
            //    }
            //}
            var result = new
            {
                ID  = customer.ID,
                FullName = customer.FullName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Birthday = customer.Birthday,
                Gender = customer.Gender,
                Address = customer.Address,
                ImageURL = customer.Image != null ? customer.Image.ImageURL : null
            };

            return Ok(result);
        }

        // GET api/customer/GetCustomers
        [Route("api/customer/GetCustomers")]
        public IQueryable GetCustomers()
        {
            return _customerService.GetAllCustomers().Select(c => new CustomerPOCO(){
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
        [Route("api/customer/GetCustomerByID/{id}")]
        [ResponseType(typeof(CustomerPOCO))]
        public IHttpActionResult GetCustomerByID(int id)
        {
            Customer customer = _customerService.GetCustomerByID(id);
            if (customer == null)
            {
                return NotFound();
            }
            var stringURL = "";
            if (customer.ImageID != null)
            {
                var image = _imageService.GetImageByID(customer.ImageID.Value);
                if (image != null)
                {
                    stringURL = image.ImageURL;
                }
            }

            CustomerPOCO poco = new CustomerPOCO()
            {
                ID = customer.ID,
                FullName = customer.FullName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Birthday = customer.Birthday,
                Gender = customer.Gender,
                Address = customer.Address,
                ImageURL = customer.Image != null ? customer.Image.ImageURL : null
            };

            return Ok(poco);
        }

        // PUT api/Customer/5
        //[Route("api/customer/GetCustomer/{id}")]
        [Route("api/customer/UpdateCustomerDetail/{id}")]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PutCustomer(int id, [FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer c = _customerService.GetCustomerByID(id);
            if (c == null)
            {
                return BadRequest();
            }

            c.FullName = customer.FullName;
            c.Email = customer.Email;
            customer.PhoneNumber = customer.PhoneNumber;
            c.Birthday = customer.Birthday;
            c.Gender = customer.Gender;
            c.Address = customer.Address;
            c.ImageID = 1; //TODO

            _customerService.UpdateCustomer(customer);

            return Ok(customer);
        }

        // POST api/Customer
        [Route("api/customer/CreateAccount")]
        [ResponseType(typeof(CustomerPOCO))]
        public IHttpActionResult PostCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = _customerService.AddCustomer(customer);

            if (!success)
            {
                return BadRequest(ModelState);
            }
            return CreatedAtRoute("DefaultApi", new { id = customer.ID }, customer);
        }

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