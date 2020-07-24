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
    public class AccessService : IAccessService
    {
        public readonly IAccessRepository _accessRepository;
        public readonly IDeviceRepository _deviceRepository;
        public readonly IUnitOfWork _unitOfWork;

        public AccessService(IAccessRepository accessRepository, IDeviceRepository deviceRepository, IUnitOfWork unitOfWork)
        {
            this._accessRepository = accessRepository;
            this._deviceRepository = deviceRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<AccessResponse> AuthAsync(int code)
        {
            try
            {
                var exist = await _deviceRepository.FindByIdAsync(code);
                if( exist == null)
                {
                    return new AccessResponse($"Device {code} not found");
                }

                Access access = await _accessRepository.AuthByDeviceAsync(exist.Code);
                await _unitOfWork.CompleteAsync();

                return new AccessResponse(access);
            }
            catch (Exception e)
            {
                return new AccessResponse($"An error occurred when deleting the access: { e.Message }");
            }
        }

        public async Task<AccessResponse> DeleteAsync(int code)
        {
            try
            {
                var exist = await _accessRepository.FindByIdAsync(code);
                AccessResponse response = exist == null ? new AccessResponse($"Access {code} not found") : new AccessResponse(exist);

                _accessRepository.Remove(exist);
                await _unitOfWork.CompleteAsync();

                return response;
            }
            catch (Exception e)
            {
                return new AccessResponse($"An error occurred when deleting the access: { e.Message }");
            }
        }

        public async Task<AccessResponse> FindAsync(int code)
        {
            try
            {
                var exist = await _accessRepository.FindByIdAsync(code);
                AccessResponse response = exist == null ? new AccessResponse($"Access {code} not found") : new AccessResponse(exist);

                return response;
            }
            catch (Exception e)
            {
                return new AccessResponse($"An error occurred when deleting the access: { e.Message }");
            }
        }

        public async Task<List<Access>> ListAsync()
        {
            return await _accessRepository.ListAsync();
        }

        public async Task<AccessResponse> SaveAsync(Access access)
        {
            try
            {
                await _accessRepository.AddAsync(access);
                await _unitOfWork.CompleteAsync();

                return new AccessResponse(access);
            }
            catch (Exception e)
            {
                return new AccessResponse($"An error occurred when saving the access: {e.Message}");
            }
        }

        public async Task<AccessResponse> UpdateAsync(int code, Access access)
        {   
            try
            {
                var exist = await _accessRepository.FindByIdAsync(code);
                AccessResponse response = exist == null ? new AccessResponse($"Access {code} not found") : new AccessResponse(exist);

                exist.CodeControl = access.CodeControl != 0 ? access.CodeControl : exist.CodeControl;

                exist.CodeStudent = access.CodeStudent != 0 ? access.CodeStudent : exist.CodeStudent;

                exist.CodeDevice = access.CodeDevice != 0 ? access.CodeDevice : exist.CodeDevice;

                _accessRepository.Update(exist);
                await _unitOfWork.CompleteAsync();

                return response;
            }
            catch (Exception e)
            {
                return new AccessResponse($"An error occurred when updating the access: { e.Message }");
            }
        }
    }
}
