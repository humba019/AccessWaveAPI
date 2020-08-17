using AccessWave.Domain.Models;
using AccessWave.Resources.Entities;
using AccessWave.Services.Communications;
using AccessWave.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Controllers
{
    [Route("rule")]
    public class RuleController : Controller
    {
        private readonly IRuleService _ruleService;
        private readonly IMapper _mapper;

        public RuleController(IRuleService ruleService, IMapper mapper)
        {
            _ruleService = ruleService;
            _mapper = mapper;
        }

        // GET: rule
        [HttpGet]
        public async Task<IEnumerable<RuleResource>> GetAllAsync()
        {
            var rules = await _ruleService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Rule>, IEnumerable<RuleResource>>(rules);

            return resources;
        }

        /*
        [HttpGet("find")]
        public async Task<ActionResult<RuleResource>> FindAsync([System.Web.Http.FromUri]Rule rule)
        {
            var result = await _ruleService.FindAsync(rule.Code);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var resource = _mapper.Map<Rule, RuleResource>(result.Rule);

            return Ok(resource);
        }
        */

        [HttpPost]
        public async Task<ActionResult<RuleResource>> SaveAsync([FromBody]Rule rule)
        {
            var result = await _ruleService.SaveAsync(rule);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var resource = _mapper.Map<Rule, RuleResource>(result.Rule);

            return Ok(resource);
        }
    }
}
