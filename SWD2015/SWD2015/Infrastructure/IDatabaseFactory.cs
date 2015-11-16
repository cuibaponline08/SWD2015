using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD2015.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        SWD2015.Models.DB_9DFD26_SWD2015Entities Get();
    }
}
