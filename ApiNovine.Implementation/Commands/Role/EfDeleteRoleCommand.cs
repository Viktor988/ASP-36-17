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
	public class EfDeleteRoleCommand : IDeleteRoleCommand
	{
		private readonly ApiNovineContext context;
		private readonly DeleteRoleValidator validator;
		public EfDeleteRoleCommand(ApiNovineContext context, DeleteRoleValidator validator)
		{
			this.context = context;
			this.validator = validator;

		}
		public int Id => 20;

		public string Name => "Delete Role";

		public void Execute(DeleteRoleDto request)
		{
			validator.ValidateAndThrow(request);
			var role = context.Roles.Find(request.Id);
			if (role == null)
			{
				throw new EntityNotFoundException(request.Id, typeof(ApiNovine.Domain.Entities.Role));
			}
			role.DeletedAt = DateTime.Now;
			role.IsDeleted = true;
			role.IsActive = false;
			context.SaveChanges();
		}
	}
}
