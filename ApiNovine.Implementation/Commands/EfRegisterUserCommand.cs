using ApiNovine.Application.Commands;
using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Email;
using ApiNovine.DataAccess;
using ApiNovine.Domain.Entities;
using ApiNovine.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Implementation.Commands
{
	public class EfRegisterUserCommand : IRegisterUserCommand
	{
		private readonly ApiNovineContext context;
		private readonly RegisterUserValidator _validator;
		private readonly IEmailSender _sender;
		public EfRegisterUserCommand(ApiNovineContext context, RegisterUserValidator validator,IEmailSender sender)
		{
			this.context = context;
			_validator = validator;
			_sender = sender;
		}
		public int Id => 31;

		public string Name => "User Registration";

		public void Execute(RegisterUserDto request)
		{
			_validator.ValidateAndThrow(request);
			var user = new User
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Username = request.Username,
				Email = request.Email,
				Password = request.Password,
				RoleId = 2
			};
			var lista = new List<int> {7,33,1,2,12,11,22 };
			foreach (var a in lista) {
				user.UserUseCases.Add(new UserUseCase
				{
					UseCaseId =a



				});
			}
			context.Users.Add(user);
			context.SaveChanges();
			_sender.Send(new SendEmailDto
			{
				Subject = "Registration",
				Content = "Successfull Registration ",
				SendTo = request.Email
			});
		}
	}
}
