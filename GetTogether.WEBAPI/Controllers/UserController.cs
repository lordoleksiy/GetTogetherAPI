﻿using GetTogether.BLL.Interfaces;
using GetTogether.Common.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetTogether.WEBAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<UserDTO>>> GetAll() 
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDTO>> GetAsync(int userId)
        {
            var sample = await _userService.GetById(userId);
            return Ok(sample);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody]NewUserDTO userDTO)
        {
            var user = await _userService.Post(userDTO);
            return Ok(user);
        }
    }
}
