using Microsoft.AspNetCore.Mvc;
using MyToDoDemo.Common.Dtos;
using MyToToDemo.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToToDemo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ApiResponse> Login(string account, string pwd) => await userService.LoginAsync(account, pwd);
        [HttpPost]
        public async Task<ApiResponse> Register([FromQuery] UserDto userDto) => await userService.Register(userDto);
    }
}
