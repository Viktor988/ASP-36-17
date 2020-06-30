using ApiNovine.Application.Commands;
using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using ApiNovine.Domain.Entities;
using ApiNovine.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ApiNovine.Implementation.Commands
{
	public class EfCreatePostCommand : ICreatePostCommand
	{
		private readonly ApiNovineContext context;
		private readonly CreatePostValidator _validator;
		public EfCreatePostCommand(ApiNovineContext context, CreatePostValidator validator)
		{
			this.context = context;
			_validator = validator;
		
		}
		public int Id => 13;

		public string Name => "Create post";


		public void Execute(InsertPostDto request)
		{
			_validator.ValidateAndThrow(request);


			var post = new ApiNovine.Domain.Entities.Post
			{
				Content = request.Content,
				Title = request.Title,
				CategoryId = request.CategoryId,
				PictureId = request.PictureId,
				DateCreated = DateTime.Now
			};

			foreach (var tag in request.TagPosts)
			{
				post.TagPosts.Add(new TagPost
				{
					TagId = tag.TagId
				});



			}
			context.Add(post);
			context.SaveChanges();

		}
	}
}
