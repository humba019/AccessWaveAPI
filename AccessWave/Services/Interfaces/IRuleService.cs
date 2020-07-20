using AccessWave.Domain.Models;
using AccessWave.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Services.Interfaces
{
    public interface IRuleService
    {
        Task<IEnumerable<Rule>> ListAsync();
        Task<RuleResponse> SaveAsync(Rule rule);
        Task<RuleResponse> UpdateAsync(int code, Rule rule);
        Task<RuleResponse> DeleteAsync(int code);
    }
}
