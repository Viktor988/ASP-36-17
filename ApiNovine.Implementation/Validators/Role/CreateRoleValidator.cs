using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Validators.Role
{
	public class CreateRoleValidator : AbstractValidator<InsertRoleDto>
	{
		public CreateRoleValidator(ApiNovineContext context)
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name can't be empty");
			RuleFor(x => x.Name).Matches("^[A-z]{2,}$");
			RuleFor(x => x.Name).Must(name => !context.Roles.Any(g =>g.Name==name))
				 .WithMessage(p => $"Rule with the name of {p.Name} already exists in database.");
		}
	}
}
