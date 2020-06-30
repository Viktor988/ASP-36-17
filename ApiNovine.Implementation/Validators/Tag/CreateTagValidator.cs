using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Validators
{
	public class CreateTagValidator: AbstractValidator<TagDto>
	{
		public CreateTagValidator(ApiNovineContext context)
		{	
		
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name can't be empty");
			RuleFor(x => x.Name).Matches(@"[A-z\s]+");
			RuleFor(x => x.Name).Must(name => !context.Tags.Any(g => g.Name == name))
				 .WithMessage(p => $"Tag with the name of {p.Name} already exists in database.");
		}
	}
}
