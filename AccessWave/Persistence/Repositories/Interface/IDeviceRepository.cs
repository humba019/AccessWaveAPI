using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Persistence.Repositories.Interface
{
    public interface IDeviceRepository
    {
        Task<List<Device>> ListAsync();
        Task AddAsync(Device device);
        Task<Device> FindByIdAsync(int id);
        void Update(Device device);
        void Remove(Device device);
    }
}
