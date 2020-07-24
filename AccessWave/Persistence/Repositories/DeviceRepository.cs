using AccessWave.Domain.Models;
using AccessWave.Persistence.Context;
using AccessWave.Persistence.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Persistence.Repositories
{
    public class DeviceRepository : BaseRepository, IDeviceRepository
    {
        public DeviceRepository(DatabaseContext context) : base(context){}

        public async Task AddAsync(Device device)
        {
            await _context.Device.AddAsync(device);
        }

        public async Task<Device> FindByIdAsync(int id)
        {
            Device device = await _context.Device.FindAsync(id);
            if (device != null)
            {
                if (device.UserName != "")
                {
                    device.User = await _context.User.FindAsync(device.UserName);
                }
            }

            return device;
        }

        public async Task<List<Device>> ListAsync()
        {
            List<Device> list = new List<Device>();
            foreach (Device device in await _context.Device.ToListAsync())
            {
                if (device.UserName != "")
                {
                    device.User = await _context.User.FindAsync(device.UserName);
                }

                list.Add(device);
            }

            return list;

        }

        public void Remove(Device device)
        {
            _context.Device.Remove(device);
        }

        public void Update(Device device)
        {
            _context.Device.Update(device);
        }
    }
}
