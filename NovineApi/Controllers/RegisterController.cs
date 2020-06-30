using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNovine.Application;
using ApiNovine.Application.Commands;
using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NovineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        
        private readonly UseCaseExecutor executor;
    
        
        public RegisterController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // POST: api/Register
        [HttpPost]
        public IActionResult Post([FromBody] RegisterUserDto dto,[FromServices]IRegisterUserCommand command )
        {
            executor.ExecuteCommand(command, dto);
            return   StatusCode(201);
        }

      
    }
}
