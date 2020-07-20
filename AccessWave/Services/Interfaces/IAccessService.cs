using AccessWave.Domain.Models;
using AccessWave.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Services.Interfaces
{
    public interface IAccessService
    {
        Task<IEnumerable<Access>> ListAsync();
        Task<AccessResponse> SaveAsync(Access access);
        Task<AccessResponse> UpdateAsync(int code, Access access);
        Task<AccessResponse> DeleteAsync(int code);
    }
}
