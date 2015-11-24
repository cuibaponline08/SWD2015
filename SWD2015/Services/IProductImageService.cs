
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD2015.Services
{
    public interface IProductImageService
    {
        IQueryable<Models.Product_Image> GetProductImagesByProductID(int productID);
    }
}
