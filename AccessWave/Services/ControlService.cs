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
    public class ControlService : IControlService
    {
        public readonly IControlRepository _controlRepository;
        public readonly IUnitOfWork _unitOfWork;

        public ControlService(IControlRepository controlRepository, IUnitOfWork unitOfWork)
        {
            this._controlRepository = controlRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<ControlResponse> DeleteAsync(int code)
        {
            try
            {
                var exist = await _controlRepository.FindByIdAsync(code);
                ControlResponse response = exist == null ? new ControlResponse($"Control {code} not found") : new ControlResponse(exist);

                _controlRepository.Remove(exist);
                await _unitOfWork.CompleteAsync();

                return response;
            }
            catch (Exception e)
            {
                return new ControlResponse($"An error occurred when deleting the control: { e.Message }");
            }
        }

        public async Task<ControlResponse> FindAsync(int code)
        {
            try
            {
                var exist = await _controlRepository.FindByIdAsync(code);
                ControlResponse response = exist == null ? new ControlResponse($"Control {code} not found") : new ControlResponse(exist);

                return response;
            }
            catch (Exception e)
            {
                return new ControlResponse($"An error occurred when finding the control: { e.Message }");
            }
        }

            public async Task<List<Control>> ListAsync()
        {
            return await _controlRepository.ListAsync();
        }

        public async Task<ControlResponse> SaveAsync(Control control)
        {
            try
            {
                await _controlRepository.AddAsync(control);
                await _unitOfWork.CompleteAsync();

                return new ControlResponse(control);
            }
            catch (Exception e)
            {
                return new ControlResponse($"An error occurred when saving the control: {e.Message}");
            }
        }

        public async Task<ControlResponse> UpdateAsync(int code, Control control)
        {
            try
            {
                var exist = await _controlRepository.FindByIdAsync(code);
                ControlResponse response = exist == null ? new ControlResponse($"Control {code} not found") : new ControlResponse(exist);

                exist.Description = control.Description != "" ? control.Description : exist.Description;

                exist.Entry = control.Entry != "" ? control.Entry : exist.Entry;

                exist.Exit = control.Exit != "" ? control.Exit : exist.Exit;

                _controlRepository.Update(exist);
                await _unitOfWork.CompleteAsync();

                return response;
            }
            catch (Exception e)
            {
                return new ControlResponse($"An error occurred when updating the control: { e.Message }");
            }
        }
    }
}
