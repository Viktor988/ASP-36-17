using ApiNovine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.DataTransfer
{
	public class UserUpdateDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		
		public string Username { get; set; }
		public string Password { get; set; }

		public int RoleId { get; set; }

		
		public List<int> UserCase { get; set; }
		
	}
}
