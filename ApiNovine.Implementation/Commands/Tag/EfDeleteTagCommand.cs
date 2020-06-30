using ApiNovine.Application.Commands;
using ApiNovine.Application.Exceptions;
using ApiNovine.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Implementation.Commands
{
	public class EfDeleteTagCommand : IDeleteTagCommand
	{
		private readonly ApiNovineContext context;

		public EfDeleteTagCommand(ApiNovineContext context)
		{
			this.context = context;

		}
		public int Id => 25;

		public string Name => "Delete tag";

		public void Execute(int request)
		{
			var tag = context.Tags.Find(request);
			if (tag == null)
			{
				throw new EntityNotFoundException(request, typeof(ApiNovine.Domain.Entities.Tag));
			}

			tag.DeletedAt = DateTime.Now;
			tag.IsDeleted = true;
			tag.IsActive = false;
			context.SaveChanges();
		}
	}
}
