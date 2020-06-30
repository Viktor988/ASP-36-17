using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using ApiNovine.Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApiNovine.Implementation.Validators
{
	public class RegisterUserValidator:AbstractValidator<RegisterUserDto>
	{
		
		public RegisterUserValidator(ApiNovineContext context)
		{
			
			RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is required")
			.Matches("^[A-z]{2,}$");
			RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required")
			.Matches("^[A-z]{2,}$"); ;
			RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MinimumLength(7);
			RuleFor(x => x.Username).NotEmpty().MinimumLength(5).Must(c => !context.Users.Any(u => u.Username == c)).WithMessage("Username is already taken");
			RuleFor(x => x.Email).NotEmpty().EmailAddress().MinimumLength(5).Must(c => !context.Users.Any(u => u.Email == c)).WithMessage("Email is already taken");
		
		}
	}
}
