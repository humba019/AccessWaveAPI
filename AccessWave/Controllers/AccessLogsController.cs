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
    [Route("access/logs")]
    public class AccessLogsController : Controller
    {
        private readonly IAccessService _accessService;
        private readonly IMapper _mapper;

        public AccessLogsController(IAccessService accessService, IMapper mapper)
        {
            _accessService = accessService;
            _mapper = mapper;
        }

        // GET: access/logs
        [HttpGet]
        public async Task<List<AccessLogResource>> GetAllAsync()
        {
            var accesses = await _accessService.ListLogsAsync();
            var resources = _mapper.Map<List<AccessLog>, List<AccessLogResource>>(accesses);

            return resources;
        }

        [HttpGet("find")]
        public async Task<ActionResult<AccessLogResource>> FindAsync([System.Web.Http.FromUri]Access access)
        {
            var result = await _accessService.FindLogAsync(access.Code);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var resource = _mapper.Map<AccessLog, AccessLogResource>(result.Access);

            return Ok(resource);
        }

    }
}
