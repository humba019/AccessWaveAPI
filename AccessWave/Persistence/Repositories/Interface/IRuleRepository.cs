using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Persistence.Repositories.Interface
{
    public interface IRuleRepository
    {
        Task<IEnumerable<Rule>> ListAsync();
        Task AddAsync(Rule rule);
        Task<Rule> FindByIdAsync(int id);
        void Update(Rule rule);
        void Remove(Rule rule);
    }
}
