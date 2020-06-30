using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Domain.Entities
{
	public class Comment:Entity
	{
	

		public string Content { get; set; }
		public DateTime DateCreated { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }
		public Post Post { get; set; }
		public int PostId { get; set; }
	}
}
