using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApiNovine.Implementation.Validators
{
	public class CreateCategoryValidator:AbstractValidator<CategoryDto>
	{

		public CreateCategoryValidator(ApiNovineContext context)
		{
			
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name can't be empty");
			RuleFor(x => x.Name).Matches(@"[A-z\s]+");

			RuleFor(x => x.Name).Must(name => !context.Categories.Any(g => g.Name == name))
				 .WithMessage(p => $"Category with the name of {p.Name} already exists in database.");
		}
	}
}
