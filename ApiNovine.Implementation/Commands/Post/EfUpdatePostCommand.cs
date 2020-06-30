using ApiNovine.Application.Commands.Post;
using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using ApiNovine.Domain.Entities;
using ApiNovine.Implementation.Validators.Post;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using ApiNovine.Application.Exceptions;

namespace ApiNovine.Implementation.Commands.Post
{
	public class EfUpdatePostCommand : IUpdatePostCommand
	{
		private readonly ApiNovineContext context;
		private readonly UpdatePostValidator _validator;
		public EfUpdatePostCommand(ApiNovineContext context,UpdatePostValidator validator)
		{
			_validator = validator;
			this.context = context;

		}
		public int Id => 14;

		public string Name => "Update post";

		
		public void Execute(UpdatePostDto request)
		{
			_validator.ValidateAndThrow(request);
			var post = context.Posts.Include(x => x.TagPosts).FirstOrDefault(x => x.Id == request.Id);
			if (post == null)
			{
				throw new EntityNotFoundException(request.Id, typeof(ApiNovine.Domain.Entities.Post));
			}
			post.Title = request.Title;
			post.Content = request.Content;
			post.CategoryId = request.CategoryId;
			post.PictureId = request.PictureId;

			var TagDelete = post.TagPosts.Where(x => !request.TagPosts.Contains(x.TagId));
			foreach (var c in TagDelete)
			{
				c.IsActive = false;
				c.IsDeleted = true;
				c.DeletedAt = DateTime.Now;

			}
			var tagIds = post.TagPosts.Select(x => x.TagId);
			var TagInsert = request.TagPosts.Where(x => !tagIds.Contains(x));
			foreach (var tagid in TagInsert)
			{
				post.TagPosts.Add(new TagPost
				{
					TagId = tagid
				});
			}

			context.SaveChanges();

		}
	}
}
