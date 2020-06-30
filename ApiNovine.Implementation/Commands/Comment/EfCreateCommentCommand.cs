using ApiNovine.Application;
using ApiNovine.Application.Commands;
using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using ApiNovine.Domain.Entities;
using ApiNovine.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ApiNovine.Implementation.Validators.Comment;

namespace ApiNovine.Implementation.Commands
{
	public class EfcreateCommentCommand : ICreateCommentCommand
	{
		private readonly ApiNovineContext context;
		private readonly IApplicationActor actor;
		private readonly CreateCommentValidator validator;
		public EfcreateCommentCommand(ApiNovineContext context,IApplicationActor actor, CreateCommentValidator validator)
		{
			this.context = context;
			this.actor = actor;
			this.validator = validator;

		}
		public int Id => 7;

		public string Name => "Create comment";

		public void Execute(CreateCommentDto request)
		{
			validator.ValidateAndThrow(request);
			var comments = new Domain.Entities.Comment
			{
				PostId = request.PostId,
				UserId = actor.Id,
				Content = request.Content,
				DateCreated=DateTime.Now
			};
			context.Comments.Add(comments);
			context.SaveChanges();
		}
	}
}
