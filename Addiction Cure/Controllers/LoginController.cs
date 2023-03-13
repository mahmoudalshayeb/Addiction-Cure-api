﻿using Addiction_Cure.core.data;
using Addiction_Cure.core.DTO;
using Addiction_Cure.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Addiction_Cure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost]
        public IActionResult Login(Loginac login)
        {
            var token = loginService.Login(login);
            if (token == null)
                return Unauthorized();
            else
                return Ok(token);
        }

        [HttpPost]
        [Route("register")]
        public Register register(Register patient)
        {
            return loginService.register(patient);
        }
    }
}
