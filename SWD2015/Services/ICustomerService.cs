using SWD2015.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD2015.Services
{
    public interface ICustomerService
    {
        Customer CheckLogin(string email, string password);
        IQueryable<Customer> GetAllCustomers();
        Customer GetCustomerByID(int customerID);
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(Customer customer);
    }
}
