using ApiNovine.Application.Commands.Role;
using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Exceptions;
using ApiNovine.DataAccess;
using ApiNovine.Implementation.Validators.Role;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Implementation.Commands.Role
{
	public class EfUpdateRoleCommand : IUpdateRoleCommand
	{
		private readonly ApiNovineContext context;
		private readonly UpdateRoleValidator _validator;
		public EfUpdateRoleCommand(ApiNovineContext context, UpdateRoleValidator validator)
		{
			this.context = context;
			_validator = validator;
		}
		public int Id => 19;

		public string Name => "Update role";

		public void Execute(UpdateRoleDto request)
		{
			_validator.ValidateAndThrow(request);
			var role = context.Roles.Find(request.Id);
			if (role == null)
			{
				throw new EntityNotFoundException(request.Id, typeof(ApiNovine.Domain.Entities.Role));
			}
			role.Name = request.Name;
			context.SaveChanges();
		}
	}
}
