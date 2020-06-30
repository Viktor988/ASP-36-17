using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNovine.Application.DataTransfer;
using Microsoft.AspNetCore.Mvc;
using NovineApi.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NovineApi.Controllers
{
	[Route("api/[controller]")]
	public class TokenController : Controller
	{
		private readonly JwtManager manager;
		public TokenController(JwtManager manager)
		{
			this.manager = manager;
		}

		
		// POST api/<controller>
		[HttpPost]
		public IActionResult Post([FromBody] LoginDto request)
		{
			var token = manager.MakeToken(request.UserName, request.Password);
			if (token == null)
			{
				return Unauthorized();
			}
			return Ok(new
			{

				token
			}) ;
		}

		



	}
}
