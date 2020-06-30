using ApiNovine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.DataTransfer
{
	public class InsertUserDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }

		public int RoleId { get; set; }
		public string Password { get; set; }


		public IEnumerable<UserCaseDto> UserUseCases { get; set; } = new List<UserCaseDto>();
	}
}
