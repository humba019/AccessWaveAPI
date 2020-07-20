using AccessWave.Domain.Models;
using AccessWave.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Services.Interfaces
{
    public interface IEducationService
    {
        Task<IEnumerable<Education>> ListAsync();
        Task<EducationResponse> SaveAsync(Education education);
        Task<EducationResponse> UpdateAsync(int code, Education education );
        Task<EducationResponse> DeleteAsync(int code);
    }
}
