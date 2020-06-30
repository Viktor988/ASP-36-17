using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNovine.Application;
using ApiNovine.Application.Commands;
using ApiNovine.Application.Commands.Comment;
using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries;
using ApiNovine.Application.Queries.Comment;
using ApiNovine.Application.Searches;
using ApiNovine.Implementation.Validators.Comment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NovineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;
     

        public CommentController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;

      
        }
        // GET: api/Comment
        [HttpGet]
        public IActionResult Get([FromQuery] CommentSearch search,[FromServices]IGetCommentsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Comment/5
        [HttpGet("{id}", Name = "Getcc")]
        public IActionResult Get(int id,[FromQuery] CommentsDto dto,[FromServices] IGetCommentQuery comment)
        {
            return Ok(executor.ExecuteQuery(comment, id));
           
        }

        // POST: api/Comment
        [HttpPost]
        public IActionResult Post([FromBody] CreateCommentDto dto, [FromServices]ICreateCommentCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCommentDto dto,[FromServices] IUpdateCommentCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteCommentCommand command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(204);
        }
    }
}
