using AccessWave.Domain.Models;
using AccessWave.Persistence.Repositories.Interface;
using AccessWave.Services.Communications;
using AccessWave.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Services
{
    public class DeviceService : IDeviceService
    {
        public readonly IDeviceRepository _deviceRepository;
        public readonly IUnitOfWork _unitOfWork;

        public DeviceService(IDeviceRepository deviceRepository, IUnitOfWork unitOfWork)
        {
            this._deviceRepository = deviceRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<DeviceResponse> DeleteAsync(int id)
        {
            try
            {
                var exist = await _deviceRepository.FindByIdAsync(id);
                DeviceResponse response = exist == null ? new DeviceResponse($"Device {id} not found") : new DeviceResponse(exist);

                _deviceRepository.Remove(exist);
                await _unitOfWork.CompleteAsync();

                return response;
            }
            catch (Exception e)
            {
                return new DeviceResponse($"An error occurred when deleting the access: { e.Message }");
            }
        }

        public async Task<DeviceResponse> FindAsync(int id)
        {
            try
            {
                var exist = await _deviceRepository.FindByIdAsync(id);
                DeviceResponse response = exist == null ? new DeviceResponse($"Device {id} not found") : new DeviceResponse(exist);

                return response;
            }
            catch (Exception e)
            {
                return new DeviceResponse($"An error occurred when deleting the access: { e.Message }");
            }
        }

        public async Task<List<Device>> ListAsync()
        {
            return await _deviceRepository.ListAsync();
        }

        public async Task<DeviceResponse> SaveAsync(Device device)
        {
            try
            {
                await _deviceRepository.AddAsync(device);
                await _unitOfWork.CompleteAsync();

                return new DeviceResponse(device);
            }
            catch (Exception e)
            {
                return new DeviceResponse($"An error occurred when saving the access: {e.Message}");
            }
        }

        public async Task<DeviceResponse> UpdateAsync(int id, Device device)
        {   
            try
            {
                var exist = await _deviceRepository.FindByIdAsync(id);
                DeviceResponse response = exist == null ? new DeviceResponse($"Device {id} not found") : new DeviceResponse(exist);

                exist.UserName = device.UserName != "" ? device.UserName : exist.UserName;

                exist.FirstBlock = device.FirstBlock != "" ? device.FirstBlock : exist.FirstBlock;

                exist.SecondBlock = device.SecondBlock != "" ? device.SecondBlock : exist.SecondBlock;

                exist.ThirdBlock = device.ThirdBlock != "" ? device.ThirdBlock : exist.ThirdBlock;

                exist.FourthBlock = device.FourthBlock != "" ? device.FourthBlock : exist.FourthBlock;

                _deviceRepository.Update(exist);
                await _unitOfWork.CompleteAsync();
                 
                return response;
            }
            catch (Exception e)
            {
                return new DeviceResponse($"An error occurred when updating the access: { e.Message }");
            }
        }
    }
}
