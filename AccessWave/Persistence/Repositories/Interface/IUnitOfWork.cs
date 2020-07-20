using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Persistence.Repositories.Interface
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
 
}
