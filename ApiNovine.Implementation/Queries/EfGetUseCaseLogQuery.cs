using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries;
using ApiNovine.Application.Searches;
using ApiNovine.DataAccess;
using ApiNovine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Queries
{
	public class EfGetUseCaseLogQuery : IGetUseCaseLogQuery
	{
		private readonly ApiNovineContext _context;
		public EfGetUseCaseLogQuery(ApiNovineContext context)
		{
			_context = context;
		}
		public int Id => 32;

		public string Name => "Get UsecaseLog";

		public PagedResponse<UseCaseLogDto> Execute(UseCaseLogSearch search)
		{
			var use = _context.UseCaseLogs.AsQueryable();
			if (!string.IsNullOrEmpty(search.UserName) || !string.IsNullOrWhiteSpace(search.UserName))
			{
				use = use.Where(x => x.Actor.ToLower().Contains(search.UserName.ToLower()));
			}
			if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
			{
				use = use.Where(x => x.UseCaseName.ToLower().Contains(search.Name.ToLower()));
			}
			if (search.DateFrom != null && search.DateFrom>=search.DateTo)
			{
				use = use.Where(x => x.Date >= search.DateFrom);
			}
			if (search.DateTo != null && search.DateTo > search.DateFrom)
			{
				use = use.Where(x => x.Date <= search.DateTo);
			}
			var skipCount = search.PerPage * (search.Page - 1);
			var us = new PagedResponse<UseCaseLogDto>
			{
				CurrentPage = search.Page,
				PostsPerPage = search.PerPage,
				TotalCount = use.Count(),
				Items = use.Skip(skipCount).Take(search.PerPage).Select(c => new UseCaseLogDto
				{
					Actor = c.Actor,
					Data = c.Data,
					Date = c.Date,
					UseCaseName = c.UseCaseName
				}).ToList()

			};
			return us;

		
		} 
	}
}
