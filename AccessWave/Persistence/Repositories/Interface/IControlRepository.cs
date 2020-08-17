using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Persistence.Repositories.Interface
{
    public interface IControlRepository
    {
        Task<List<Control>> ListAsync();
        Task AddAsync(Control control);
        Task<Control> FindByIdAsync(int id);
        void Update(Control control);
        void Remove(Control control);
    }
}
