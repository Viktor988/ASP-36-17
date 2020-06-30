using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Domain.Entities
{
	public class Role:Entity
	{
		
		public string Name { get; set; }

		public IEnumerable<User> Users { get; set; } = new List<User>();
	}
}
