using ApiNovine.Application.Commands.Comment;
using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Implementation.Commands.Comment
{
	public class EfUpdateCommentCommand : IUpdateCommentCommand
	{
		private readonly ApiNovineContext context;

		public EfUpdateCommentCommand(ApiNovineContext context)
		{
			this.context = context;

		}
		public int Id => 34;

		public string Name => "Update comment";

		public void Execute(UpdateCommentDto request)
		{
			var comment = context.Comments.Find(request.Id);

			comment.Content = request.Content;
			comment.DateCreated = DateTime.Now;

			context.SaveChanges();
		}
	}
}
