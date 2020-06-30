using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Domain.Entities
{
	public class Category:Entity
	{
		public string Name { get; set; }

		public IEnumerable<Post> Posts { get; set; }
	}
}
