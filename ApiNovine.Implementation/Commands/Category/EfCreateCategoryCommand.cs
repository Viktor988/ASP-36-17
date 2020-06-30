using ApiNovine.Application.Commands;
using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using ApiNovine.Domain.Entities;
using ApiNovine.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Implementation.Commands
{
	public class EfCreateCategoryCommand : ICreateCategoryCommand
	{
		private readonly ApiNovineContext context;
		private readonly CreateCategoryValidator _validator;
		public EfCreateCategoryCommand(ApiNovineContext context, CreateCategoryValidator validator)
		{
			this.context = context;
			_validator = validator;
		}
		public int Id => 3;

		public string Name => "Create category";

		public void Execute(CategoryDto request)
		{
			_validator.ValidateAndThrow(request);
			var category = new Category
			{
				Name = request.Name
			};

			context.Categories.Add(category);
			context.SaveChanges();
		}
	}
}
