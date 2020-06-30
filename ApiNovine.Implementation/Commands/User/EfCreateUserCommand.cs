using ApiNovine.Application.Commands;
using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using ApiNovine.Domain.Entities;
using ApiNovine.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using FluentValidation;
using ApiNovine.Implementation.Validators.User;
using ApiNovine.Application.Searches;

namespace ApiNovine.Implementation.Commands
{
	public class EfCreateUserCommand : ICreateUserCommand
	{
		private readonly ApiNovineContext context;
		private readonly InsertUserValidation validation;
		public EfCreateUserCommand(ApiNovineContext context, InsertUserValidation validation)
		{
			this.context = context;
			this.validation = validation;

		}
		public int Id => 28;

		public string Name => "Create user";

		public void Execute(InsertUserDto request)
		{
			validation.ValidateAndThrow(request);

			var user = new User
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Password = request.Password,
				Username = request.Username,
				Email = request.Email,
				RoleId=request.RoleId	
			};
			foreach(var x in request.UserUseCases)
			{
				user.UserUseCases.Add(new UserUseCase
				{
					UseCaseId = x.UserCaseId,
					

				});
			}
			
			context.Users.Add(user);
			context.SaveChanges();
		}


	}
}
