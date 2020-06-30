using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNovine.Application;
using ApiNovine.Application.Commands.Rate;
using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries.Rate;
using ApiNovine.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NovineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public RateController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }
        // GET: api/Rate
        [HttpGet]
        public IActionResult Get([FromQuery] RateSearch search,[FromServices] IGetRatesQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        //// GET: api/Rate/5
        [HttpGet("{id}", Name = "GetRate")]
        public IActionResult Get(int id,[FromServices] IGetRateQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Rate
        [HttpPost]
        public IActionResult Post([FromBody] InsertRateDto dto,[FromServices] ICreateRateCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT: api/Rate/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateRateDto dto,[FromServices] IUpdateRateCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(204);
                
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteRateCommand command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(204);
        }
    }
}
