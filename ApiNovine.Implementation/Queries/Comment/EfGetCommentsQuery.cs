using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries;
using ApiNovine.Application.Searches;
using ApiNovine.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Queries
{
	public class EfGetCommentsQuery : IGetCommentsQuery
	{
		private readonly ApiNovineContext _context;
		public EfGetCommentsQuery(ApiNovineContext context)
		{
			_context = context;
		}
		public int Id => 6;

		public string Name => "Get comments";

		public PagedResponse<CommentsDto> Execute(CommentSearch search)
		{
			var comments = _context.Comments.Include(x => x.Post).Include(x => x.User).AsQueryable();
			
			if (!string.IsNullOrEmpty(search.UserName) || !string.IsNullOrWhiteSpace(search.UserName))
			{
				comments = comments.Where(c => c.User.Username.ToLower().Contains(search.UserName.ToLower()));
			}
			var skipCount = search.PerPage * (search.Page - 1);
			var comment = new PagedResponse<CommentsDto>
			{
				CurrentPage = search.Page,
				PostsPerPage = search.PerPage,
				TotalCount = comments.Count(),
				Items = comments.Skip(skipCount).Take(search.PerPage).Select(c => new CommentsDto
				{
					Id = c.Id,
					Content = c.Content,
					DateCreated = c.DateCreated,
					UserName = c.User.Username



				}).ToList()
			};

		return comment;
				}
		}
}
