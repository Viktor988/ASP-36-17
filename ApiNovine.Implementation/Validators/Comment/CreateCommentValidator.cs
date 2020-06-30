using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApiNovine.Implementation.Validators.Comment
{
	public class CreateCommentValidator:AbstractValidator<CreateCommentDto>
	{
		private readonly ApiNovineContext context;
		public CreateCommentValidator(ApiNovineContext context)
		{
			this.context = context;
		
			RuleFor(x => x.PostId).Must(PostExists).WithMessage("Post with an id of {PropertyValue} doesn't exist.");
			RuleFor(x => x.Content).NotEmpty().WithMessage("Comment is required");



		}

		public bool PostExists(int postId)
		{
			return context.Posts.Any(x => x.Id == postId);
		}
	}
}
