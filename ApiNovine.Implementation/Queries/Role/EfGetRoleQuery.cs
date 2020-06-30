using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Exceptions;
using ApiNovine.Application.Queries.Role;
using ApiNovine.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Implementation.Queries.Role
{
	public class EfGetRoleQuery : IGetRoleQuery
	{
		private readonly ApiNovineContext _context;
		public EfGetRoleQuery(ApiNovineContext context)
		{
			_context = context;
		}
		public int Id => 17;

		public string Name => "Get role";

		public GetRoleDto Execute(int search)
		{
			var role = _context.Roles.Find(search);
			if (role == null)
			{
				throw new EntityNotFoundException(search, typeof(ApiNovine.Domain.Entities.Role));
			}
			return new GetRoleDto
			{
				Id = role.Id,
				Name = role.Name
			};
		}
	}
}
