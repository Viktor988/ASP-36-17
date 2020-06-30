using System;
using System.Collections.Generic;
using System.Text;
using ApiNovine.Application.DataTransfer;
using FluentValidation;
namespace ApiNovine.Implementation.Validators.Comment
{
	public class UpdateCommentValidator:AbstractValidator<UpdateCommentDto>
	{
		public UpdateCommentValidator()
		{
			RuleFor(x => x.Content).NotEmpty().WithMessage("Comment is required");
		}
	}
}
