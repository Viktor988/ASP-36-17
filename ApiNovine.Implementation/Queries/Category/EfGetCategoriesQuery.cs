using ApiNovine.Application.Commands;
using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries;
using ApiNovine.DataAccess;
using ApiNovine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Http;
using ApiNovine.Application.Searches;

namespace ApiNovine.Implementation.Queries
{
	public class EfGetCategoriesQuery : IGetCategoriesQuery
	{
		private readonly ApiNovineContext _context;
		public EfGetCategoriesQuery(ApiNovineContext context)
		{
			_context = context;
		}
		public int Id => 1;

		public string Name => "Get categories";

		public PagedResponse<CategoryDto> Execute(CategorySearch search)
		{
			var categories = _context.Categories.AsQueryable();
		
			if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
			{
				categories = categories.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
			}
			var skipcount = search.PerPage * (search.Page - 1);
		
			var cats = new PagedResponse<CategoryDto>
			{
				CurrentPage = search.Page,
				PostsPerPage = search.PerPage,
				TotalCount = categories.Count(),
				Items = categories.Skip(skipcount).Take(search.PerPage).Select(x => new CategoryDto
				{
					Id = x.Id,
					Name = x.Name
				})

			};



			return cats;
			
		
			
		}
	}
}
