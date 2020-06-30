using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApiNovine.Implementation.Validators.Category
{
	public class DeleteCategoryValidator:AbstractValidator<DeleteCategoryDto>
	{
		private readonly ApiNovineContext context;
		public DeleteCategoryValidator(ApiNovineContext context)
		{
			this.context = context;
			RuleFor(x => x.Id).Must(CategoryExist).WithMessage("Post with  CategoryId={PropertyValue} Exist");
		}

		public bool CategoryExist(int CategoryId)
		{
			return !context.Posts.Any(cc => cc.CategoryId == CategoryId);
		}
	}
}
