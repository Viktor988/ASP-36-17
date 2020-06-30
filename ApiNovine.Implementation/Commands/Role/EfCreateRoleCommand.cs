using ApiNovine.Application.Commands.Role;
using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using ApiNovine.Implementation.Validators.Role;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Implementation.Commands.Role
{
	public class EfCreateRoleCommand : ICreateRoleCommand
	{
		private readonly ApiNovineContext context;
		private readonly CreateRoleValidator _validator;
		public EfCreateRoleCommand(ApiNovineContext context, CreateRoleValidator validator)
		{
			this.context = context;
			_validator = validator;
		}
		public int Id => 18;

		public string Name => "Insert role";

		public void Execute(InsertRoleDto request)
		{
			_validator.ValidateAndThrow(request);
			var role = new ApiNovine.Domain.Entities.Role
			{
				Name = request.Name


			};
			context.Roles.Add(role);
			context.SaveChanges();

		}
	}
}
		
	
	
	

