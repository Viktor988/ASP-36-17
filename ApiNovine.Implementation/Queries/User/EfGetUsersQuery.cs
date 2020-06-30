using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries;
using ApiNovine.Application.Searches;
using ApiNovine.DataAccess;
using ApiNovine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Queries
{
	public class EfGetUsersQuery : IGetUsersQuery
	{
		private readonly ApiNovineContext _context;
		public EfGetUsersQuery(ApiNovineContext context)
		{
			_context = context;
		}
		public int Id => 26;

		public string Name => "Get Users";

		public PagedResponse<GetUsersDto> Execute(UserSearch search)
		{
			var users = _context.Users.Include(x=>x.Role).AsQueryable();
			if (!string.IsNullOrEmpty(search.UserName) || !string.IsNullOrWhiteSpace(search.UserName))
			{
				users = users.Where(x => x.Username.ToLower().Contains(search.UserName.ToLower()));
			}
			if (!string.IsNullOrEmpty(search.Email) || !string.IsNullOrWhiteSpace(search.Email))
			{
				users = users.Where(x => x.Email.ToLower().Contains(search.Email.ToLower()));
			}
			if (!string.IsNullOrEmpty(search.RoleName) || !string.IsNullOrWhiteSpace(search.RoleName))
			{
				users = users.Where(x => x.Role.Name.ToLower().Contains(search.RoleName.ToLower()));
			}
			var skipCount = search.PerPage * (search.Page - 1);
			var user = new PagedResponse<GetUsersDto>
			{
				CurrentPage = search.Page,
				PostsPerPage = search.PerPage,
				TotalCount = users.Count(),
				Items = users.Skip(skipCount).Take(search.PerPage).Select(c => new GetUsersDto
				{  
				Id=c.Id,
				Email=c.Email,
				FirstName=c.FirstName,
				LastName=c.LastName,
				Password=c.Password,
				Username=c.Username,
				RoleId=c.Role.Id,
				RoleName=c.Role.Name

					

				}).ToList()


			};
			return user;
		}
	}
}
