using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Validators.User
{
	public class InsertUserValidation : AbstractValidator<InsertUserDto>
	{
		private readonly ApiNovineContext context;
		public InsertUserValidation(ApiNovineContext context)
		{
			this.context = context;

			RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is required")
			.Matches("^[A-z]{2,}$");
			RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required")
			.Matches("^[A-z]{2,}$"); ;
			RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MinimumLength(7);
			RuleFor(x => x.Username).NotEmpty().MinimumLength(5).Must(c => !context.Users.Any(u => u.Username == c)).WithMessage("Username is already taken");
			RuleFor(x => x.Email).NotEmpty().EmailAddress().MinimumLength(5).Must(c => !context.Users.Any(u => u.Email == c)).WithMessage("Email is already taken");
			RuleFor(x => x.RoleId).Must(RoleExist).WithMessage("Role with an id of {PropertyValue} doesn't exist.");
			
			RuleFor(x => x.UserUseCases).Must(c => c.Select(v => v.UserCaseId).Distinct().Count() == c.Count())
				.WithMessage("Duplicate usecaseid are not allowed.");
			RuleFor(x => x.UserUseCases.Count()).GreaterThan(0).WithMessage("User must contain more than 0 UserUseCase");
			RuleForEach(x => x.UserUseCases).ChildRules(tags =>
			{
				tags.RuleFor(x => x.UserCaseId).Must(UseCaseExist).WithMessage("{PropertyValue} Usecase not exist");
				
			});


		}
		public bool UseCaseExist(int idUse)
		{
			return Enum.IsDefined(typeof(UseCaseEnum), idUse);
		}
		private bool RoleExist(int RoleId)
		{
			return context.Roles.Any(x => x.Id == RoleId);
		}
	}
}
