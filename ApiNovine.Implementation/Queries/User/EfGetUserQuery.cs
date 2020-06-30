using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Exceptions;
using ApiNovine.Application.Queries;
using ApiNovine.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Queries
{
	public class EfGetUserQuery : IGetUserQuery
	{
		private readonly ApiNovineContext _context;
		public EfGetUserQuery(ApiNovineContext context)
		{
			_context = context;
		}
		public int Id => 27;

		public string Name => "Get user";

		public UserDto Execute(int search)
		{
			var user = _context.Users.Include(x => x.Comments).Include(x => x.UserUseCases).Include(x=>x.Role).FirstOrDefault(x=>x.Id==search);
			if (user == null)
			{
				throw new EntityNotFoundException(search, typeof(ApiNovine.Domain.Entities.User));
			}

			return new UserDto
			{
				LastName = user.LastName,
				FirstName = user.FirstName,
				Email = user.Email,
				Id = user.Id,
				Password = user.Password,
				Username = user.Username,
				RoleId=user.Role.Id,
				RoleName=user.Role.Name,
				userCases=user.UserUseCases.Select(x=>new UserCaseDto
				{
					UserCaseId=x.UseCaseId,
					UserId=x.UserId
					
				})

			};
		}
	}
}
