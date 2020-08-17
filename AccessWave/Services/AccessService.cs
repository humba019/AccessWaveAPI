using AccessWave.Domain.Models;
using AccessWave.Persistence.Repositories.Interface;
using AccessWave.Services.Communications;
using AccessWave.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TimeZoneConverter;

namespace AccessWave.Services
{
    public class AccessService : IAccessService
    {
        public readonly IAccessRepository _accessRepository;
        public readonly IAccessLogRepository _accessLogRepository;
        public readonly IDeviceRepository _deviceRepository;
        public readonly IControlRepository _controlRepository;
        public readonly IUnitOfWork _unitOfWork;

        public AccessService(IAccessRepository accessRepository, IAccessLogRepository accessLogRepository, IDeviceRepository deviceRepository, IControlRepository controlRepository, IUnitOfWork unitOfWork)
        {
            this._accessLogRepository = accessLogRepository;
            this._accessRepository = accessRepository;
            this._deviceRepository = deviceRepository;
            this._controlRepository = controlRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<AccessResponse> AuthAsync(int code)
        {
            try
            {
                CultureInfo ci = new CultureInfo("en-US");
                TimeZoneInfo hrBrasilia = TZConvert.GetTimeZoneInfo("E. South America Standard Time");
                var exist = await _deviceRepository.FindByIdAsync(code);
                if( exist == null && code != 0)
                {
                    return new AccessResponse($"Device {code} not found");
                }

                Access access = await _accessRepository.AuthByDeviceAsync(exist.Code);
                access.AccessLogs = await _accessLogRepository.ListByAccessCodeAsync(access.Code);
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
                if (exist != null)
                {
                    exist.AccessLogs = await _accessLogRepository.ListByAccessCodeAsync(code);
                }
                AccessResponse response = exist == null ? new AccessResponse($"Access {code} not found") : new AccessResponse(exist);

                return response;
            }
            catch (Exception e)
            {
                return new AccessResponse($"An error occurred when finding the access: { e.Message }");
            }
        }

        public async Task<AccessLogResponse> FindLogAsync(int code)
        {
            try
            {
                var exist = await _accessLogRepository.FindByIdAsync(code);
                AccessLogResponse response = exist == null ? new AccessLogResponse($"AccessLog {code} not found") : new AccessLogResponse(exist);

                return response;
            }
            catch (Exception e)
            {
                return new AccessLogResponse($"An error occurred when finding the accesslog: { e.Message }");
            }
        }

        public async Task<AccessResponse> FisrtReadAsync(Device device)
        {
            try
            {
                CultureInfo ci = new CultureInfo("en-US");
                TimeZoneInfo hrBrasilia = TZConvert.GetTimeZoneInfo("E. South America Standard Time");
                Device deviceOut = new Device();
                device = await _deviceRepository.AddAsync(device);
                foreach (Access accessIn in await _accessRepository.ListAsync())
                {
                    string firstKey = accessIn.Device.FirstBlock + "" + accessIn.Device.SecondBlock + "" + accessIn.Device.ThirdBlock + "" + accessIn.Device.FourthBlock;
                    string secondKey = device.FirstBlock + "" + device.SecondBlock + "" + device.ThirdBlock + "" + device.FourthBlock;
                    if (firstKey == secondKey)
                    {
                        deviceOut = accessIn.Device;
                    }
                }

                Access access = new Access();
                AccessLog accessLog = new AccessLog();
                if (deviceOut.Code != 0)
                {
                    return new AccessResponse($"Device {deviceOut.Code} already exists.");
                }
                else if(deviceOut.Code == 0)
                {

                    access = new Access { Entry = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, hrBrasilia).ToString(), Exit = "Waiting", CodeDevice = device.Code, Device = device, CodeControl = 1 };
                    await _accessRepository.AddAsync(access);
                    await _unitOfWork.CompleteAsync();
                }
                access.AccessLogs = await _accessLogRepository.ListByAccessCodeAsync(access.Code);
                return new AccessResponse(access);
            }
            catch (Exception e)
            {
                return new AccessResponse($"An error occurred when saving the access: {e.Message}");
            }

        }

        public async Task<List<Access>> ListAsync()
        {
            List<Access> list = new List<Access>();
            foreach (Access access in await _accessRepository.ListAsync())
            {
                access.AccessLogs = await _accessLogRepository.ListByAccessCodeAsync(access.Code);
                list.Add(access);
            }
            return list;
        }

        public Task<List<AccessLog>> ListLogsAsync()
        {
            return _accessLogRepository.ListAsync();
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
