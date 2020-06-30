using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Validators.Role
{
	public class UpdateRoleValidator : AbstractValidator<UpdateRoleDto>
	{
		public UpdateRoleValidator(ApiNovineContext context)
		{
			RuleFor(x => x.Name).Matches("^[A-z]{2,}$");
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name can't be empty")

			.Must((dto, name) => !context.Roles.Any(g => g.Name == name && g.Id != dto.Id))
			 .WithMessage(p => $"Role with the name of {p.Name} already exists in database.");
		}
	}
}
