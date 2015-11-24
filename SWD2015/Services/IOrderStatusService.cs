using SWD2015.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD2015.Services
{
    public interface IOrderStatusService
    {
        Order_Status GetOrderStatusByID(int id);
    }
}
