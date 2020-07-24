using AccessWave.Domain.Models;
using AccessWave.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Services.Interfaces
{
    public interface IDeviceService
    {
        Task<List<Device>> ListAsync();
        Task<DeviceResponse> FindAsync(int id);
        Task<DeviceResponse> SaveAsync(Device device);
        Task<DeviceResponse> UpdateAsync(int id, Device device);
        Task<DeviceResponse> DeleteAsync(int id);
    }
}
