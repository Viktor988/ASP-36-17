using ApiNovine.Application.Commands;
using ApiNovine.Application.Exceptions;
using ApiNovine.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Implementation.Commands
{
	public class EfDeleteUserCommand : IDeleteUserCommand
	{
		private readonly ApiNovineContext context;

		public EfDeleteUserCommand(ApiNovineContext context)
		{
			this.context = context;

		}
		public int Id => 30;

		public string Name => "Delete user";

		public void Execute(int request)
		{
			var user = context.Users.Find(request);
			if (user == null)
			{
				throw new EntityNotFoundException(request, typeof(ApiNovine.Domain.Entities.User));
			}
			user.DeletedAt = DateTime.Now;
			user.IsDeleted = true;
			user.IsActive = false;
			context.SaveChanges();
		}
	}
}
