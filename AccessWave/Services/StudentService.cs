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
    public class StudentService : IStudentService
    {
        public readonly IStudentRepository _studentRepository;
        public readonly IUnitOfWork _unitOfWork;

        public StudentService(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            this._studentRepository = studentRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<StudentResponse> DeleteAsync(int code)
        {
            try
            {
                var exist = await _studentRepository.FindByIdAsync(code);
                StudentResponse response = exist == null ? new StudentResponse($"Student {code} not found") : new StudentResponse(exist);

                _studentRepository.Remove(exist);
                await _unitOfWork.CompleteAsync();

                return response;
            }
            catch (Exception e)
            {
                return new StudentResponse($"An error occurred when deleting the student: { e.Message }");
            }
        }

        public async Task<IEnumerable<Student>> ListAsync()
        {
            return await _studentRepository.ListAsync();
        }

        public async Task<StudentResponse> SaveAsync(Student student)
        {
            try
            {
                await _studentRepository.AddAsync(student);
                await _unitOfWork.CompleteAsync();

                return new StudentResponse(student);
            }
            catch (Exception e)
            {
                return new StudentResponse($"An error occurred when saving the student: {e.Message}");
            }
        }

        public async Task<StudentResponse> UpdateAsync(int code, Student student)
        {
            try
            {
                var exist = await _studentRepository.FindByIdAsync(code);
                StudentResponse response = exist == null ? new StudentResponse($"Student {code} not found") : new StudentResponse(exist);

                exist.UserName = student.UserName != "" ? student.UserName : exist.UserName;

                exist.CodePeriod = student.CodePeriod != 0 ? student.CodePeriod : exist.CodePeriod;

                exist.CodeEducation = student.CodeEducation != 0 ? student.CodeEducation : exist.CodeEducation;

                _studentRepository.Update(exist);
                await _unitOfWork.CompleteAsync();

                return response;
            }
            catch (Exception e)
            {
                return new StudentResponse($"An error occurred when updating the student: { e.Message }");
            }
        }
    }
}
