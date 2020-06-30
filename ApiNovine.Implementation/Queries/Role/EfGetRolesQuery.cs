using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries.Role;
using ApiNovine.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Queries.Role
{
	public class EfGetRolesQuery : IGetRolesQuery
	{
		private readonly ApiNovineContext _context;
		public EfGetRolesQuery(ApiNovineContext context)
		{
			_context = context;
		}
		public int Id => 16;

		public string Name => "Get roles";

		public List<GetRoleDto> Execute(GetRoleDto search)
		{
			var roles = _context.Roles.ToList();

			var rol=roles.Select(x => new GetRoleDto
			{
				Id = x.Id,
				Name = x.Name
			}).ToList();
			return rol.ToList();
		}
	}
}
