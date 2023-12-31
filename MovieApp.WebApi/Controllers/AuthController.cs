﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Core.Entities.Concrete;
using MovieApp.Business.Abstract;
using MovieApp.Entities.DTOs.UserDtos;

namespace MovieApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDTO userLogin)
        {
            var result = _authService.Login(userLogin);
            if(!result.Success)
                return BadRequest();
            return Ok(result);
        }





        [HttpPost("register")]
        public IActionResult Reggister([FromBody] UserRegisterDTO userRegister)
        {


            var result = _authService.Register(userRegister);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
