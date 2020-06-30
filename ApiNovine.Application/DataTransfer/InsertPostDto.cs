using ApiNovine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.DataTransfer
{
	public class InsertPostDto
	{
	
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime DateCreated { get; set; }
		public int CategoryId { get; set; }
		public int PictureId { get; set; }
		public IEnumerable<TagPostsDto> TagPosts { get; set; } = new List<TagPostsDto>();
	}
}
