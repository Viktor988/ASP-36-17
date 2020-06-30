using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNovine.Application;
using ApiNovine.Application.Commands;
using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries;
using ApiNovine.Application.Searches;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NovineApi.Controllers
{
	[Route("api/[controller]")]
	public class CategoryController : Controller
	{
		private readonly IApplicationActor actor;
		private readonly UseCaseExecutor executor;

		public CategoryController(IApplicationActor actor, UseCaseExecutor executor)
		{
			this.actor = actor;
			this.executor = executor;
		}

		// GET: api/<controller>
		[HttpGet]

		public IActionResult Get([FromServices] IGetCategoriesQuery query,[FromQuery] CategorySearch dto)
		{
			return Ok(executor.ExecuteQuery(query,dto));
		}

		// GET api/<controller>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id,[FromServices] IGetCategoryQuery command)
		{
			
			return Ok(executor.ExecuteQuery(command, id));
		}

		// POST api/<controller>
		[HttpPost]
		public IActionResult Post([FromBody] CategoryDto dto,[FromServices]ICreateCategoryCommand command)
		{
			
			
				executor.ExecuteCommand(command, dto);
				return StatusCode(201);
				
			
			
		}

		// PUT api/<controller>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] CategoryDto dto,[FromServices] IUpdateCategoryCommand command)
		{
			
				dto.Id = id;
				executor.ExecuteCommand(command, dto);
				return StatusCode(204);


		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id,[FromQuery] DeleteCategoryDto dto,[FromServices] IDeleteCategoryCommand command)
		{
			dto.Id = id;
			
				executor.ExecuteCommand(command, dto);
				return StatusCode(204);
			
			
		}
		
	}
}
