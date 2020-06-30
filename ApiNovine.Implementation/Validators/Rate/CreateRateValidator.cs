using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ApiNovine.Application;
using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApiNovine.Implementation.Validators.Rate
{
	public class CreateRateValidator:AbstractValidator<InsertRateDto>
	{
		private readonly ApiNovineContext context;
		private readonly IApplicationActor actor;
		public CreateRateValidator(ApiNovineContext context, IApplicationActor actor)
		{
			this.context = context;
			this.actor = actor;


			RuleFor(x => x.PostId).Must((dto, name) => !context.Rates.Any(g=> g.PostId == dto.PostId && actor.Id==g.UserId)).WithMessage("You have already rated this news");
			RuleFor(x => x.PostId).Must(PostExists).WithMessage("Post with an id of {PropertyValue} doesn't exist.");
			RuleFor(x => x.Mark).NotEmpty().WithMessage("Mark is required")
			.GreaterThan(0).LessThan(6);
		
		}

		
		
		public bool PostExists(int postId)
		{
			return context.Posts.Any(x => x.Id == postId);
		}
	}
}
