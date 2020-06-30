using ApiNovine.Application;
using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Exceptions;
using ApiNovine.Application.Queries;
using ApiNovine.DataAccess;
using ApiNovine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Implementation.Queries
{
	public class EfGetCategoryQuery : IGetCategoryQuery
	{
		private readonly ApiNovineContext _context;
		private readonly IApplicationActor actor;
		public EfGetCategoryQuery(ApiNovineContext context, IApplicationActor actor)
		{
			_context = context;
			this.actor = actor;
		}
		public int Id => 2;

		public string Name => "Get category";

		public CategoryDto Execute(int search)
		{
			var cat = _context.Categories.Find(search);
			if (cat == null)
			{
				throw new EntityNotFoundException(search,typeof(Category));
			}

			return new CategoryDto

			{   Id=cat.Id,
				Name = cat.Name
			};
		}
	}
}
