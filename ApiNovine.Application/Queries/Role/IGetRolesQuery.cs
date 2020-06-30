using ApiNovine.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.Queries.Role
{
	public interface IGetRolesQuery:IQuery<GetRoleDto,List<GetRoleDto>>
	{
	}
}
