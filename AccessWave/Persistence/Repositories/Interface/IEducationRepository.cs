using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Persistence.Repositories.Interface
{
    public interface IEducationRepository
    {
        Task<IEnumerable<Education>> ListAsync();
        Task AddAsync(Education education);
        Task<Education> FindByIdAsync(int id);
        void Update(Education education);
        void Remove(Education education);
    }
}
