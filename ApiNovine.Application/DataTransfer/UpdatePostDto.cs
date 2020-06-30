using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.DataTransfer
{
	public class UpdatePostDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public int CategoryId { get; set; }
		public int PictureId { get; set; }
		
		public ICollection<int> TagPosts { get; set; } = new List<int>();
	}
}
