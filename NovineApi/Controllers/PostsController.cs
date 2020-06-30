using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNovine.Application;
using ApiNovine.Application.Commands;
using ApiNovine.Application.Commands.Post;
using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries;
using ApiNovine.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NovineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public PostsController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }
        // GET: api/Posts
        [HttpGet]
        public IActionResult Get([FromServices] IGetPostsQuery query,[FromQuery]PostSearch dto)
        {

            return Ok(executor.ExecuteQuery(query, dto));

        }

        // GET: api/Posts/5
        [HttpGet("{id}", Name = "GetPost")]
        public IActionResult Get(int id, [FromServices] IGetPostQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Posts
        [HttpPost]
        public IActionResult Post([FromBody] InsertPostDto dto,[FromServices] ICreatePostCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdatePostDto dto,[FromServices] IUpdatePostCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeletePostCommand command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(204);
        }
        


    }
}
