using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Persistence.Repositories.Interface
{
    public interface IAccessRepository
    {
        Task<IEnumerable<Access>> ListAsync();
        Task AddAsync(Access access);
        Task<Access> FindByIdAsync(int id);
        void Update(Access access);
        void Remove(Access access);
    }
}
