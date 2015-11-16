using SWD2015.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWD2015.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private DB_9DFD26_SWD2015Entities _dataContext;
        public DB_9DFD26_SWD2015Entities Get()
        {
            var entity = new DB_9DFD26_SWD2015Entities();
            return _dataContext ?? (_dataContext = entity);
        }

        protected override void DisposeCore()
        {
            if (_dataContext != null)
            {
                _dataContext.Dispose();
            }
        }
    }
}