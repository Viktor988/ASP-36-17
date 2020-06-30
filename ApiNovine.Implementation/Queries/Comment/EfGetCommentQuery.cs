using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries.Comment;
using ApiNovine.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Queries.Comment
{
	public class EfGetCommentQuery : IGetCommentQuery
	{
		private readonly ApiNovineContext _context;
		public EfGetCommentQuery(ApiNovineContext context)
		{
			_context = context;
		}
		public int Id => 35;

		public string Name => "Get comment";

		public CommentsDto Execute(int search)
		{
			var comment = _context.Comments.Include(x=>x.User).FirstOrDefault(a=>a.Id==search);
			return new CommentsDto
			{
				Id = comment.Id,
				UserName = comment.User.Username,
				Content = comment.Content,
				DateCreated = comment.DateCreated
			};
		}
	}
}
