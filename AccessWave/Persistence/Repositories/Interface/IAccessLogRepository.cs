using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Persistence.Repositories.Interface
{
    public interface IAccessLogRepository
    {
        Task<List<AccessLog>> ListAsync();
        Task<List<AccessLog>> ListByAccessCodeAsync(int code);
        Task AddAsync(AccessLog accessLog);
        Task<AccessLog> FindByIdAsync(int code);
        void Update(AccessLog accessLog);
        void Remove(AccessLog accessLog);
    }
}
