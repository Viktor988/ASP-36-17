using ApiNovine.Application.Commands;
using ApiNovine.Application.Exceptions;
using ApiNovine.DataAccess;
using ApiNovine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Implementation.Commands
{
	public class EfDeleteCommentCommand : IDeleteCommentCommand
	{
		private readonly ApiNovineContext context;

		public EfDeleteCommentCommand(ApiNovineContext context)
		{
			this.context = context;

		}
		public int Id => 8;

		public string Name => "Delete comment";

		public void Execute(int request)
		{
			var comment = context.Comments.Find(request);
			if (comment == null)
			{
				throw new EntityNotFoundException(request, typeof(ApiNovine.Domain.Entities.Comment));
			}

			comment.DeletedAt = DateTime.Now;
			comment.IsDeleted = true;
			comment.IsActive = false;
			context.SaveChanges();

		}
	}
}
