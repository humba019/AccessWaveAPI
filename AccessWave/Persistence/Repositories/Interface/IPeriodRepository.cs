using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Persistence.Repositories.Interface
{
    public interface IPeriodRepository
    {
        Task<IEnumerable<Period>> ListAsync();
        Task AddAsync(Period period);
        Task<Period> FindByIdAsync(int id);
        void Update(Period period);
        void Remove(Period period);
    }
}
