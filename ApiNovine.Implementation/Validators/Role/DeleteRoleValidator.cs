using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using FluentValidation;
namespace ApiNovine.Implementation.Validators.Role
{
	public class DeleteRoleValidator:AbstractValidator<DeleteRoleDto>
	{
		private readonly ApiNovineContext context;
		public DeleteRoleValidator(ApiNovineContext context)
		{
			this.context = context;
			RuleFor(x => x.Id).Must(UserExist).WithMessage("User with  RoleId={PropertyValue} Exist");
		}

		public bool UserExist(int RoleId)
		{
			return !context.Users.Any(cc => cc.RoleId == RoleId);
		}
	}
}

