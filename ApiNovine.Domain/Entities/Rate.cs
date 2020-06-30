using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Domain.Entities
{
	public class Rate:Entity
	{
		public int PostId { get; set; }
		public int UserId { get; set; }

		public Post Post { get; set; }
		public User User { get; set; }
		public int Mark { get; set; }

	}
}
