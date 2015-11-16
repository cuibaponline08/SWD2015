using SWD2015.Infrastructure;
using SWD2015.Models;
using SWD2015.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IRepository<Employee> _employeeRepository = new EmployeeRepository();

        public Employee GetEmployeeByID(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public IQueryable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }


        public void Save()
        {
            _employeeRepository.Save();
        }
    }
}