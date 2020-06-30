using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Validators
{
	public class UpdateTagValidator : AbstractValidator<TagDto>
	{
		public UpdateTagValidator(ApiNovineContext context)
		{
			RuleFor(x => x.Name).Matches(@"[A-z\s]+");
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name can't be empty")
			.Must((dto, name) => !context.Tags.Any(g => g.Name == name && g.Id != dto.Id))
			 .WithMessage(p => $"Tag with the name of {p.Name} already exists in database.");
		}
	}
}
