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
    public class EmployeeService : IEmployeeService
    {
        public readonly IEmployeeRepository _employeeRepository;
        public readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            this._employeeRepository = employeeRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<EmployeeResponse> DeleteAsync(int code)
        {
            try
            {
                var exist = await _employeeRepository.FindByIdAsync(code);
                EmployeeResponse response = exist == null ? new EmployeeResponse($"Employee {code} not found") : new EmployeeResponse(exist);

                _employeeRepository.Remove(exist);
                await _unitOfWork.CompleteAsync();

                return response;
            }
            catch (Exception e)
            {
                return new EmployeeResponse($"An error occurred when deleting the employee: { e.Message }");
            }
        }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _employeeRepository.ListAsync();
        }

        public async Task<EmployeeResponse> SaveAsync(Employee employee)
        {
            try
            {
                await _employeeRepository.AddAsync(employee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(employee);
            }
            catch (Exception e)
            {
                return new EmployeeResponse($"An error occurred when saving the employee: {e.Message}");
            }
        }

        public async Task<EmployeeResponse> UpdateAsync(int code, Employee employee)
        {
            try
            {
                var exist = await _employeeRepository.FindByIdAsync(code);
                EmployeeResponse response = exist == null ? new EmployeeResponse($"Employee {code} not found") : new EmployeeResponse(exist);

                exist.UserName = employee.UserName != "" ? employee.UserName : exist.UserName;

                exist.CodePeriod = employee.CodePeriod != 0 ? employee.CodePeriod : exist.CodePeriod;

                _employeeRepository.Update(exist);
                await _unitOfWork.CompleteAsync();

                return response;
            }
            catch (Exception e)
            {
                return new EmployeeResponse($"An error occurred when updating the employee: { e.Message }");
            }
        }
    }
}
