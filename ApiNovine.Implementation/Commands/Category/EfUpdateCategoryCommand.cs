using ApiNovine.Application.Commands;
using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Exceptions;
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
	public class EfUpdateCategoryCommand : IUpdateCategoryCommand
	{
		private readonly ApiNovineContext context;
		private readonly UpdateCategoryValidator _validator;
		public EfUpdateCategoryCommand(ApiNovineContext context, UpdateCategoryValidator validator)
		{
			this.context = context;
			_validator = validator;
		}
		public int Id => 4;

		public string Name => "Update Category";

		public void Execute(CategoryDto request)
		{
			_validator.ValidateAndThrow(request);
			if (request == null)
			{
				throw new EntityNotFoundException(request.Id, typeof(Category));
			}
			var category = context.Categories.Find(request.Id);
			category.Name = request.Name;			
			context.SaveChanges();
		}
	}
}
