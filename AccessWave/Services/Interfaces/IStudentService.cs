using AccessWave.Domain.Models;
using AccessWave.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> ListAsync();
        Task<StudentResponse> SaveAsync(Student student);
        Task<StudentResponse> UpdateAsync(int code, Student student);
        Task<StudentResponse> DeleteAsync(int code);
    }
}
