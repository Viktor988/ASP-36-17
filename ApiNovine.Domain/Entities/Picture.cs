using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Domain.Entities
{
	public class Picture:Entity
	{
		public string Src { get; set; }
		public IEnumerable<Post> Posts { get; set; }

	}
}
