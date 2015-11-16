using SWD2015.Infrastructure;
using SWD2015.Models;
using SWD2015.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Services
{
	public class CustomerService : ICustomerService
	{
        private IRepository<Customer> _customerRepository = new CustomerRepository();

        public Customer CheckLogin(string email, string password)
        {
            var customer = _customerRepository.Get(c => c.Email == email && c.Password == password);
            //customer = _customerRepository.GetById(15);
            return customer;
        }

        public IQueryable<Models.Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Models.Customer GetCustomerByID(int customerID)
        {
            return _customerRepository.GetById(customerID);
        }

        public bool AddCustomer(Models.Customer customer)
        {
            try
            {
                _customerRepository.Add(customer);
                _customerRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateCustomer(Models.Customer customer)
        {
            var c = _customerRepository.GetById(customer.ID);
            if (c != null)
            {
                _customerRepository.Update(customer);
                _customerRepository.Save();
                return true;
            }
            return false;
        }

        public bool DeleteCustomer(Models.Customer customer)
        {
            var c = _customerRepository.GetById(customer.ID);
            if (c != null)
            {
                _customerRepository.Delete(customer);
                _customerRepository.Save();
                return true;
            }
            return false;
        }
    }
}