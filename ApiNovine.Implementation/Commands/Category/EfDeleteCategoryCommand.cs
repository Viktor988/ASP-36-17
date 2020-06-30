using ApiNovine.Application.Commands;
using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Exceptions;
using ApiNovine.DataAccess;
using ApiNovine.Implementation.Validators.Category;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ApiNovine.Domain.Entities;

namespace ApiNovine.Implementation.Commands
{
	public class EfDeleteCategoryCommand : IDeleteCategoryCommand
	{
		private readonly ApiNovineContext context;
		private readonly DeleteCategoryValidator validator;
		public EfDeleteCategoryCommand(ApiNovineContext context, DeleteCategoryValidator validator)
		{
			this.context = context;
			this.validator = validator;
			
		}
		public int Id => 5;

		public string Name => "Delete Category";

		public void Execute(DeleteCategoryDto request)
		{
			validator.ValidateAndThrow(request);
			var category = context.Categories.Find(request.Id);
			if (category == null)
			{
				throw new EntityNotFoundException(request.Id, typeof(Category));
			}

			category.DeletedAt = DateTime.Now;
			category.IsDeleted = true;
			category.IsActive = false;
			context.SaveChanges();
		
			
		}
	}
}
