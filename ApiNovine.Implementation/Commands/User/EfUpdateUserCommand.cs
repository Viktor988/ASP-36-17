using ApiNovine.Application.Commands;
using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using ApiNovine.Implementation.Validators.User;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ApiNovine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ApiNovine.Application.Exceptions;

namespace ApiNovine.Implementation.Commands
{
	public class EfUpdateUserCommand : IUpdateUserCommand
	{
	
			private readonly ApiNovineContext context;
		private readonly UpdateUserValidation validation;
			public EfUpdateUserCommand(ApiNovineContext context, UpdateUserValidation validation)
			{
				this.context = context;
			this.validation = validation;
				
			}
			public int Id => 29;

		public string Name => "Update user";

		public void Execute(UserUpdateDto request)
		{
		
			validation.ValidateAndThrow(request);
			var user = context.Users.Include(x => x.UserUseCases).FirstOrDefault(x => x.Id == request.Id);
			if (user == null)
			{
				throw new EntityNotFoundException(request.Id, typeof(ApiNovine.Domain.Entities.User));
			}


			user.FirstName = request.FirstName;
			user.LastName = request.LastName;
			user.Password = request.Password;
			user.Username = request.Username;
			user.RoleId = request.RoleId;
			var useCaseDelete = user.UserUseCases.Where(x => !request.UserCase.Contains(x.UseCaseId));
			foreach(var c in useCaseDelete)
			{
				c.IsActive = false;
				c.IsDeleted = true;
				c.DeletedAt = DateTime.Now;
				
			}
		
			var usecaseIds = user.UserUseCases.Select(x => x.UseCaseId);
			var useCaseInsert = request.UserCase.Where(x => !usecaseIds.Contains(x));
			foreach(var useid in useCaseInsert)
			{
				user.UserUseCases.Add(new UserUseCase
				{
					UseCaseId = useid
				});
			}
			
			context.SaveChanges();
		}
	}
}
