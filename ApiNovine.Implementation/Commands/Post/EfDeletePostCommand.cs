using ApiNovine.Application.Commands;
using ApiNovine.Application.Exceptions;
using ApiNovine.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Implementation.Commands
{
	public class EfDeletePostCommand : IDeletePostCommand
	{
		private readonly ApiNovineContext context;
		public EfDeletePostCommand(ApiNovineContext context)
		{
			this.context = context;

		}
		public int Id => 15;

		public string Name => "Delete post";

		public void Execute(int request)
		{
			var tag = context.Posts.Find(request);
			if (tag == null)
			{
				throw new EntityNotFoundException(request, typeof(ApiNovine.Domain.Entities.Post));
			}
			tag.DeletedAt = DateTime.Now;
			tag.IsDeleted = true;
			tag.IsActive = false;
			context.SaveChanges();
		}
	}
}
