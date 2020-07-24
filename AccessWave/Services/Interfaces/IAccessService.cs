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
        Task<List<Access>> ListAsync();
        Task<AccessResponse> FindAsync(int code);
        Task<AccessResponse> AuthAsync(int code);
        Task<AccessResponse> SaveAsync(Access access);
        Task<AccessResponse> UpdateAsync(int code, Access access);
        Task<AccessResponse> DeleteAsync(int code);
    }
}
