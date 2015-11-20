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
    public class EmployeeController : ApiController
    {
        private IEmployeeService _employeeService = new EmployeeService();

        // GET api/Employee
        public IQueryable<Employee> GetEmployees()
        {
            return _employeeService.GetAllEmployees();
        }

        // GET api/Employee/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = _employeeService.GetEmployeeByID(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        //// PUT api/Employee/5
        //public IHttpActionResult PutEmployee(int id, Employee employee)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != employee.ID)
        //    {
        //        return BadRequest();
        //    }

        //    //_employeeService.

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST api/Employee
        //[ResponseType(typeof(Employee))]
        //public IHttpActionResult PostEmployee(Employee employee)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    //db.Employees.Add(employee);
        //    //db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = employee.ID }, employee);
        //}

        //// DELETE api/Employee/5
        //[ResponseType(typeof(Employee))]
        //public IHttpActionResult DeleteEmployee(int id)
        //{
        //    Employee employee = _employeeService.GetEmployeeByID(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    //db.Employees.Remove(employee);
        //    //db.SaveChanges();

        //    return Ok(employee);
        //}
    }
}