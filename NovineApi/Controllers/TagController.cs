using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNovine.Application;
using ApiNovine.Application.Commands;
using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries;
using ApiNovine.Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NovineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public TagController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }
        // GET: api/Tag
        [HttpGet]
   
        public IActionResult Get([FromServices] IGetTagsQuery query, [FromQuery] TagSearch dto)
        {
            return Ok(executor.ExecuteQuery(query, dto));
        }

        // GET: api/Tag/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id,[FromServices] IGetTagQuery query)
        {
            return Ok(executor.ExecuteQuery(query,id));
        }

        // POST: api/Tag
        [HttpPost]
        public IActionResult Post([FromBody] TagDto dto, [FromServices] ICreateTagCommand command)
        {
          
                executor.ExecuteCommand(command, dto);
                return StatusCode(201);
            
                
            
        }

        // PUT: api/Tag/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TagDto dto,[FromServices] IUpdateTagCommand command)
        { 
            
                dto.Id = id;
                executor.ExecuteCommand(command, dto);
                return StatusCode(204);
                
          
           
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteTagCommand command)
        {
            
                executor.ExecuteCommand(command, id);
                   return StatusCode(204);


        }
    }
}
