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
    public class EducationService : IEducationService
    {
        public readonly IEducationRepository _educationRepository;
        public readonly IUnitOfWork _unitOfWork;

        public EducationService(IEducationRepository educationRepository, IUnitOfWork unitOfWork)
        {
            this._educationRepository = educationRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<EducationResponse> DeleteAsync(int id)
        {
            try
            {
                var exist = await _educationRepository.FindByIdAsync(id);
                EducationResponse response = exist == null ? new EducationResponse($"Education {id} not found") : new EducationResponse(exist);

                _educationRepository.Remove(exist);
                await _unitOfWork.CompleteAsync();

                return response;
            }
            catch (Exception e)
            {
                return new EducationResponse($"An error occurred when deleting the education: { e.Message }");
            }
        }

        public async Task<IEnumerable<Education>> ListAsync()
        {
            return await _educationRepository.ListAsync();
        }

        public async Task<EducationResponse> SaveAsync(Education education)
        {
            try
            {
                await _educationRepository.AddAsync(education);
                await _unitOfWork.CompleteAsync();

                return new EducationResponse(education);
            }
            catch (Exception e)
            {
                return new EducationResponse($"An error occurred when saving the education: {e.Message}");
            }
        }

        public async Task<EducationResponse> UpdateAsync(int id, Education education)
        {
            try
            {
                var exist = await _educationRepository.FindByIdAsync(id);
                EducationResponse response = exist == null ? new EducationResponse($"Education {id} not found") : new EducationResponse(exist);

                exist.Description = education.Description != "" ? education.Description : exist.Description;

                exist.Level = education.Level != "" ? education.Level : exist.Level;

                _educationRepository.Update(exist);
                await _unitOfWork.CompleteAsync();

                return response;
            }
            catch (Exception e)
            {
                return new EducationResponse($"An error occurred when updating the education: { e.Message }");
            }
        }
    }
}
