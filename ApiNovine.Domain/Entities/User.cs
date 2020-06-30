using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ApiNovine.Domain.Entities
{
	public class User:Entity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }

		public int RoleId { get; set; }
		public Role Role { get; set; }
		public string Password { get; set; }
		public IEnumerable<Comment> Comments { get; set; } = new HashSet<Comment>();

		public ICollection<UserUseCase> UserUseCases { get; set; } = new HashSet<UserUseCase>();
		public IEnumerable<Rate> Rates { get; set; } = new List<Rate>();

	}
}
