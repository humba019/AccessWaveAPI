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
    public class PeriodService : IPeriodService
    {
        public readonly IPeriodRepository _periodRepository;
        public readonly IUnitOfWork _unitOfWork;

        public PeriodService(IPeriodRepository periodRepository, IUnitOfWork unitOfWork)
        {
            this._periodRepository = periodRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<PeriodResponse> DeleteAsync(int code)
        {
            try
            {
                var exist = await _periodRepository.FindByIdAsync(code);
                PeriodResponse response = exist == null ? new PeriodResponse($"Period {code} not found") : new PeriodResponse(exist);

                _periodRepository.Remove(exist);
                await _unitOfWork.CompleteAsync();

                return response;
            }
            catch (Exception e)
            {
                return new PeriodResponse($"An error occurred when deleting the period: { e.Message }");
            }
        }

        public async Task<IEnumerable<Period>> ListAsync()
        {
            return await _periodRepository.ListAsync();
        }

        public async Task<PeriodResponse> SaveAsync(Period period)
        {
            try
            {
                await _periodRepository.AddAsync(period);
                await _unitOfWork.CompleteAsync();

                return new PeriodResponse(period);
            }
            catch (Exception e)
            {
                return new PeriodResponse($"An error occurred when saving the period: {e.Message}");
            }
        }

        public async Task<PeriodResponse> UpdateAsync(int code, Period period)
        {
            try
            {
                var exist = await _periodRepository.FindByIdAsync(code);
                PeriodResponse response = exist == null ? new PeriodResponse($"Period {code} not found") : new PeriodResponse(exist);

                exist.Description = period.Description != "" ? period.Description : exist.Description;

                exist.Start = period.Start != "" ? period.Start : exist.Start;

                exist.End = period.End != "" ? period.End : exist.End;

                _periodRepository.Update(exist);
                await _unitOfWork.CompleteAsync();

                return response;
            }
            catch (Exception e)
            {
                return new PeriodResponse($"An error occurred when updating the period: { e.Message }");
            }
        }
    }
}
