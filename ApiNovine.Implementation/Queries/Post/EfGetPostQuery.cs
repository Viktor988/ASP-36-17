using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries;
using ApiNovine.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ApiNovine.Domain.Entities;
using ApiNovine.Application.Exceptions;

namespace ApiNovine.Implementation.Queries
{
	public class EfGetPostQuery : IGetPostQuery
	{
		private readonly ApiNovineContext _context;
		public EfGetPostQuery(ApiNovineContext context)
		{
			_context = context;
		}
		public int Id => 12;

		public string Name => "Get post";

		public GetPostDto Execute(int search)
		{
			var post = _context.Posts.Include(x=>x.Comments).ThenInclude(x=>x.User).Include(x=>x.TagPosts).ThenInclude(x=>x.Tag).Include(x=>x.Picture).Include(x=>x.Category).Include(x=>x.Rates).FirstOrDefault(a => a.Id == search);
			if (post == null)
			{
				throw new EntityNotFoundException(search, typeof(ApiNovine.Domain.Entities.Post));
			}

			var flag = 1;
			if (post.Rates.Count() > 0)
			{
				flag = post.Rates.Count();
			}
			return new GetPostDto {

				Id = post.Id,
				Title = post.Title,
				Content = post.Content,
				DateCreated = DateTime.Now,
				CategoryName = post.Category.Name,
				PictureName = post.Picture.Src,
				PictureId = post.PictureId,
				CategoryId = post.CategoryId,
				AverageMark = (decimal)post.Rates.Sum(x => x.Mark) / flag,
				CountUser = post.Rates.Count(),

				CommentsDtos = post.Comments.Select(x => new CommentsDto
				{
					Id = x.Id,
					Content = x.Content,
					UserName = x.User.Username,
					DateCreated = x.DateCreated
				}).ToList(),
				TagDtos = post.TagPosts.Select(v => new TagDto
				{
					Name = v.Tag.Name,
					Id = v.Tag.Id
				}).ToList()


			};
		
		}
	}
}
