using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.DataTransfer
{
	public class CreateCommentDto
	{
		public string Content { get; set; }
		public DateTime DateCreated { get; set; }

		public int UserId { get; set; }
	
		public int PostId { get; set; }
	}
}
