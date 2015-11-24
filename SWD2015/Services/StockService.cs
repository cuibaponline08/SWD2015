using SWD2015.Infrastructure;
using SWD2015.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Services
{
    public class StockService : IStockService
    {
        private IRepository<Stock> _stockRepository = new Repositories.StockRepository();
        public Models.Stock GetStockByProductIDAndStatus(int productID, int statusID)
        {
            return _stockRepository.Get(s => s.ProductID == productID && s.Status == statusID && s.Amount > 0);
        }

        public IQueryable<Stock> GetAllStocks()
        {
            return _stockRepository.GetAll();
        }
    }
}