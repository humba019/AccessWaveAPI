using AccessWave.Domain.Models;
using AccessWave.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Services.Interfaces
{
    public interface IPeriodService
    {
        Task<IEnumerable<Period>> ListAsync();
        Task<PeriodResponse> SaveAsync(Period period);
        Task<PeriodResponse> UpdateAsync(int code, Period period);
        Task<PeriodResponse> DeleteAsync(int code);
    }
}
