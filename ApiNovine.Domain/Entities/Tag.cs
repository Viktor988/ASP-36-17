using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Domain.Entities
{
	public class Tag:Entity
	{
	
		public string Name { get; set; }


		public IEnumerable<TagPost> TagPosts { get; set; } = new HashSet<TagPost>();

	}
}
