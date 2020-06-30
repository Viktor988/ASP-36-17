using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNovine.Application;
using ApiNovine.Application.Queries;
using ApiNovine.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NovineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCaseLogController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public UseCaseLogController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] UseCaseLogSearch search,[FromServices] IGetUseCaseLogQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

       

       

      
    }
}
