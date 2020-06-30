using ApiNovine.Application.Commands;
using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Exceptions;
using ApiNovine.DataAccess;
using ApiNovine.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Implementation.Commands
{
	public class EfUpdateTagCommand : IUpdateTagCommand
	{
		private readonly ApiNovineContext context;
		private readonly UpdateTagValidator _validator;
		public EfUpdateTagCommand(ApiNovineContext context, UpdateTagValidator validator)
		{
			this.context = context;
			_validator = validator;
		}
		public int Id => 24;

		public string Name => "Update tag";

		public void Execute(TagDto request)
		{
			_validator.ValidateAndThrow(request);
			var tag = context.Tags.Find(request.Id);
			if (tag == null)
			{
				throw new EntityNotFoundException(request.Id, typeof(ApiNovine.Domain.Entities.Tag));
			}
			tag.Name = request.Name;
			context.SaveChanges();
		}
	}
}
