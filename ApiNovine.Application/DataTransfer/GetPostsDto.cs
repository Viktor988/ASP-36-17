using ApiNovine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ApiNovine.Application.DataTransfer
{
	public class GetPostsDto
	{
		public int Id { get; set; }
		public string Title { get; set; }

		public string Content { get; set; }
		public string CategoryName { get; set; }
		public DateTime DateCreated { get; set; }
		public string PictureName { get; set; }
		public int CategoryId { get; set; }
		public int PictureId { get; set; }
		

		public IEnumerable<CommentsDto> CommentsDtos { get; set; } = new List<CommentsDto>();
		
	
		public IEnumerable<TagDto> TagDtos { get; set; } = new List<TagDto>();
	}

	

	
}
