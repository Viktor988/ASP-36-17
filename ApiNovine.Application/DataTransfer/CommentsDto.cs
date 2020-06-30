using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.DataTransfer
{
	public class CommentsDto
	{
		public int Id { get; set; }
		public string Content { get; set; }
		public DateTime DateCreated { get; set; }
	
		public string UserName { get; set; }

	}
}
