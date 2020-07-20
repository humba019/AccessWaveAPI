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
    public class RuleService : IRuleService
    {
        public readonly IRuleRepository _ruleRepository;
        public readonly IUnitOfWork _unitOfWork;

        public RuleService(IRuleRepository ruleRepository, IUnitOfWork unitOfWork)
        {
            this._ruleRepository = ruleRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<RuleResponse> DeleteAsync(int code)
        {
            try
            {
                var exist = await _ruleRepository.FindByIdAsync(code);
                RuleResponse response = exist == null ? new RuleResponse($"Rule {code} not found") : new RuleResponse(exist);

                _ruleRepository.Remove(exist);
                await _unitOfWork.CompleteAsync();

                return response;
            }
            catch (Exception e)
            {
                return new RuleResponse($"An error occurred when deleting the rule: { e.Message }");
            }
        }

        public async Task<IEnumerable<Rule>> ListAsync()
        {
            return await _ruleRepository.ListAsync();
        }

        public async Task<RuleResponse> SaveAsync(Rule rule)
        {
            try
            {
                await _ruleRepository.AddAsync(rule);
                await _unitOfWork.CompleteAsync();

                return new RuleResponse(rule);
            }
            catch (Exception e)
            {
                return new RuleResponse($"An error occurred when saving the rule: {e.Message}");
            }
        }

        public async Task<RuleResponse> UpdateAsync(int code, Rule rule)
        {
            try
            {
                var exist = await _ruleRepository.FindByIdAsync(code);
                RuleResponse response = exist == null ? new RuleResponse($"Rule {code} not found") : new RuleResponse(exist);

                exist.Type = rule.Type != "" ? rule.Type : exist.Type;

                exist.Description = rule.Description != "" ? rule.Description : exist.Description;

                _ruleRepository.Update(exist);
                await _unitOfWork.CompleteAsync();

                return response;
            }
            catch (Exception e)
            {
                return new RuleResponse($"An error occurred when updating the rule: { e.Message }");
            }
        }
    }
}
