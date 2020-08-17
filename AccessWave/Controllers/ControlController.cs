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
    [Route("control")]
    public class ControlController : Controller
    {
        private readonly IControlService _controlService;
        private readonly IMapper _mapper;

        public ControlController(IControlService controlService, IMapper mapper)
        {
            _controlService = controlService;
            _mapper = mapper;
        }

        // GET: control
        [HttpGet]
        public async Task<List<ControlResource>> GetAllAsync()
        {
            var controls = await _controlService.ListAsync();
            var resources = _mapper.Map<List<Control>, List<ControlResource>>(controls);

            return resources;
        }

        [HttpGet("find")]
        public async Task<ActionResult<ControlResource>> FindAsync([System.Web.Http.FromUri]Control control)
        {
            var result = await _controlService.FindAsync(control.Code);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var resource = _mapper.Map<Control, ControlResource>(result.Control);

            return Ok(resource);
        }
    }
}
