using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Validators
{
	public class UpdateCategoryValidator:AbstractValidator<CategoryDto>
	{
		public UpdateCategoryValidator(ApiNovineContext context)
		{

			RuleFor(x => x.Name).NotEmpty().WithMessage("Name can't be empty");
			RuleFor(x => x.Name).Matches(@"[A-z\s]+")
			.Must((dto,name) => !context.Categories.Any(g => g.Name == name && g.Id!=dto.Id))
			 .WithMessage(p => $"Category with the name of {p.Name} already exists in database.");
		}
	}
}
