using ApiNovine.Application.Commands;
using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using ApiNovine.Domain.Entities;
using ApiNovine.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Commands
{
	public class EfCreateTagCommand : ICreateTagCommand
	{
		private readonly ApiNovineContext context;
		private readonly CreateTagValidator _validator;
		public EfCreateTagCommand(ApiNovineContext context, CreateTagValidator validator)
		{
			this.context = context;
			_validator = validator;
		}
		public int Id => 23;

		public string Name => "Create tag";

		public void Execute(TagDto request)
		{
			_validator.ValidateAndThrow(request);
			var tag = new Tag
			{
				Name = request.Name
				
				
			};
			
			context.Tags.Add(tag);
			context.SaveChanges();
		}
	}
}
