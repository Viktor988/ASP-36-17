using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNovine.Application;
using ApiNovine.Application.Commands;
using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries;
using ApiNovine.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NovineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public UserController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }
        // GET: api/User
        [HttpGet]
        public IActionResult Get([FromServices] IGetUsersQuery query,[FromQuery] UserSearch search)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(int id,[FromServices]IGetUserQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] InsertUserDto dto,[FromServices] ICreateUserCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserUpdateDto dto,[FromServices] IUpdateUserCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteUserCommand command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(204);
        }
    }
}
