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
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: User
        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);

            return resources;
        }

        /*
        [HttpGet("find")]
        public async Task<ActionResult<UserResource>> FindAsync([System.Web.Http.FromUri]User user)
        {
            var result = await _userService.FindAsync(user.Code);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var resource = _mapper.Map<User, UserResource>(result.User);

            return Ok(resource);
        }
        */

        [HttpPost]
        public async Task<ActionResult<UserResource>> SaveAsync([FromBody]User user)
        {
            var result = await _userService.SaveAsync(user);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var resource = _mapper.Map<User, UserResource>(result.User);

            return Ok(resource);
        }
    }
}
