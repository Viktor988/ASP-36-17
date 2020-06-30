using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Validators.User
{
	public class UpdateUserValidation : AbstractValidator<UserUpdateDto>
	{
		private readonly ApiNovineContext context;

		public UpdateUserValidation(ApiNovineContext context)
		{
			this.context = context;

			RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is required")
			.Matches("^[A-z]{2,}$");
			RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required")
			.Matches("^[A-z]{2,}$"); ;
			RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MinimumLength(7);
			RuleFor(x => x.Username).NotEmpty().MinimumLength(5).Must((dto, name) => !context.Users.Any(g => g.Username == name && g.Id != dto.Id)).WithMessage("Username is already taken");
			
			RuleForEach(x => x.UserCase).Must(UseCaseExist).WithMessage("{PropertyValue} Usecase not exist");
			RuleFor(x=>x.RoleId).Must(RoleExist).WithMessage("Role with an id of {PropertyValue} doesn't exist.");
			RuleFor(x => x.UserCase).Must(c => c.Select(v => v).Distinct().Count() == c.Count())
				.WithMessage("Duplicate tag are not allowed.");
		}

		public bool UseCaseExist(int idUse)
		{
			return Enum.IsDefined(typeof(UseCaseEnum), idUse);
		}
		public bool RoleExist(int id)
		{
			return context.Roles.Any(x => x.Id == id);
		}
	}
}
