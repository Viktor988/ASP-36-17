using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNovine.Application;
using ApiNovine.Application.Commands.Role;
using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries.Role;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NovineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public RoleController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }
        // GET: api/Role
        [HttpGet]
        public IActionResult Get([FromServices] IGetRolesQuery query,[FromQuery] GetRoleDto dto)
        {
            return Ok(executor.ExecuteQuery(query, dto));
        }

        // GET: api/Role/5
        [HttpGet("{id}", Name = "GetRole")]
        public IActionResult Get(int id,[FromQuery] GetRoleDto dto,[FromServices] IGetRoleQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Role
        [HttpPost]
        public IActionResult Post([FromBody] InsertRoleDto dto,[FromServices] ICreateRoleCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT: api/Role/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateRoleDto dto,[FromServices] IUpdateRoleCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromQuery] DeleteRoleDto dto,[FromServices] IDeleteRoleCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(204);
        }
    }
}
