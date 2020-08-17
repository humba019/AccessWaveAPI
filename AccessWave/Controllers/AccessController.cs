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
    [Route("access")]
    public class AccessController : Controller
    {
        private readonly IAccessService _accessService;
        private readonly IMapper _mapper;

        public AccessController(IAccessService accessService, IMapper mapper)
        {
            _accessService = accessService;
            _mapper = mapper;
        }

        // GET: access
        [HttpGet]
        public async Task<List<AccessResource>> GetAllAsync()
        {
            var accesses = await _accessService.ListAsync();
            var resources = _mapper.Map<List<Access>, List<AccessResource>>(accesses);

            return resources;
        }

        [HttpGet("find")]
        public async Task<ActionResult<AccessResource>> FindAsync([System.Web.Http.FromUri]Access access)
        {
            var result = await _accessService.FindAsync(access.Code);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var resource = _mapper.Map<Access, AccessResource>(result.Access);

            return Ok(resource);
        }

        [HttpGet("auth")]
        public async Task<ActionResult<AccessResource>> AuthAsync([System.Web.Http.FromUri]Device device)
        {
            var timeLista = TimeZoneInfo.GetSystemTimeZones();
            Console.WriteLine(timeLista);
            int code = 0;
            device.FirstBlock = Convert.ToInt32(device.FirstBlock).ToString("X");
            device.SecondBlock = Convert.ToInt32(device.SecondBlock).ToString("X");
            device.ThirdBlock = Convert.ToInt32(device.ThirdBlock).ToString("X");
            device.FourthBlock = Convert.ToInt32(device.FourthBlock).ToString("X");

            foreach (Access access in await _accessService.ListAsync())
            {
                string firstKey = access.Device.FirstBlock + "" + access.Device.SecondBlock + "" + access.Device.ThirdBlock + "" + access.Device.FourthBlock;
                string secondKey = device.FirstBlock + "" + device.SecondBlock + "" + device.ThirdBlock + "" + device.FourthBlock;
                if (firstKey == secondKey)
                {
                    code = access.Device.Code;
                }
            }
            if (code.Equals(0))
            {
                Device deviceIn = new Device { FirstBlock = device.FirstBlock, SecondBlock = device.SecondBlock, ThirdBlock = device.ThirdBlock, FourthBlock = device.FourthBlock, UserName = device.UserName};

                var result = await _accessService.FisrtReadAsync(deviceIn);


                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }

                var resource = _mapper.Map<Access, AccessResource>(result.Access);

                return Ok(resource);
            }
            else {
            
                var result = await _accessService.AuthAsync(code);


                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }

                var resource = _mapper.Map<Access, AccessResource>(result.Access);

                return Ok(resource);
            }
        }
    }
}
