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
    [Route("device")]
    public class DeviceController : Controller
    {
        private readonly IDeviceService _deviceService;
        private readonly IMapper _mapper;

        public DeviceController(IDeviceService deviceService, IMapper mapper)
        {
            _deviceService = deviceService;
            _mapper = mapper;
        }

        // GET: access
        [HttpGet]
        public async Task<List<DeviceResource>> GetAllAsync()
        {
            var devices = await _deviceService.ListAsync();
            var resources = _mapper.Map<List<Device>, List<DeviceResource>>(devices);

            return resources;
        }

        [HttpGet("find")]
        public async Task<ActionResult<DeviceResource>> FindAsync([System.Web.Http.FromUri]Device device)
        {
            var result = await _deviceService.FindAsync(device.Code);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var resource = _mapper.Map<Device, DeviceResource>(result.Device);

            return Ok(resource);
        }
    }
}
