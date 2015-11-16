using SWD2015.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD2015.Services
{
    public interface IProductService
    {
        IQueryable<Product> GetAllProducts();
        Product GetProductByID(int id);
        bool AddProduct(Product product);
        IQueryable<Product> GetNewProducts();
    }
}
