using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries;
using ApiNovine.Application.Searches;
using ApiNovine.DataAccess;
using ApiNovine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Queries
{
	public class EfGetPostsQuery : IGetPostsQuery
	{
		private readonly ApiNovineContext _context;
		public EfGetPostsQuery(ApiNovineContext context)
		{
			_context = context;
		}
		public int Id => 11;

		public string Name => "Get posts";

		public PagedResponse<GetPostsDto> Execute(PostSearch search)
		{
			var posts = _context.Posts.Include(x => x.Comments).Include(x => x.TagPosts).Include(x=>x.Category).Include(x=>x.Picture).AsQueryable();
			
			if (!string.IsNullOrEmpty(search.Title) || !string.IsNullOrWhiteSpace(search.Title))
			{
				posts = posts.Where(x => x.Title.ToLower().Contains(search.Title.ToLower()));
			}
			
			if (!string.IsNullOrEmpty(search.Content) || !string.IsNullOrWhiteSpace(search.Content))
			{
				posts = posts.Where(x => x.Content.ToLower().Contains(search.Content.ToLower()));
			}
			if (search.DateFrom != null && search.DateFrom > search.DateTo)
			{
				posts = posts.Where(x => x.DateCreated >= search.DateFrom);
			}
			if (search.DateTo != null && search.DateTo > search.DateFrom)
			{
				posts = posts.Where(x => x.DateCreated <= search.DateTo);
			}
			if (search.CategoryId>0)
			{
				posts = posts.Where(x => x.Category.Id == search.CategoryId);
			}
			posts=posts.OrderByDescending(x => x.DateCreated);
			if (search.OrderBy == "asc") 
			{
				posts = posts.OrderBy(x => x.DateCreated);
			}
			if (search.OrderBy=="desc")
			{
				posts = posts.OrderByDescending(x => x.DateCreated);
			}

			var skipCount = search.PerPage * (search.Page - 1);
			var post = new PagedResponse<GetPostsDto>
			{
				CurrentPage = search.Page,
				PostsPerPage = search.PerPage,
				TotalCount = posts.Count(),
				Items = posts.Skip(skipCount).Take(search.PerPage).Select(c => new GetPostsDto
				{
					Id=c.Id,
					Title=c.Title,
					Content=c.Content,
					DateCreated = c.DateCreated,
					CategoryName=c.Category.Name,
					PictureName=c.Picture.Src,
					PictureId=c.PictureId,
					CategoryId=c.CategoryId,
										
					CommentsDtos = c.Comments.Select(x => new CommentsDto
					{
						Id=x.Id,
						Content = x.Content,
					    UserName=x.User.Username,
						DateCreated = x.DateCreated
					}),
					TagDtos = c.TagPosts.Select(v => new TagDto
					{
						Name = v.Tag.Name,
						Id = v.Tag.Id
					})

				}).ToList()

		
			};



			return post;
		}
	}
}
