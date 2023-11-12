using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallapop.AccessData.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save();
    }
}
