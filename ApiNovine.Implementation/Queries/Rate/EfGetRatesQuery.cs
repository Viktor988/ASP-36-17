using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries;
using ApiNovine.Application.Queries.Rate;
using ApiNovine.Application.Searches;
using ApiNovine.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Queries.Rate
{
	public class EfGetRatesQuery : IGetRatesQuery
	{
		private readonly ApiNovineContext _context;
		public EfGetRatesQuery(ApiNovineContext context)
		{
			_context = context;
		}
		public int Id => 36;

		public string Name => "Get Rates";

		public PagedResponse<GetRateDto> Execute(RateSearch search)
		{
			var rates = _context.Rates.Include(x=>x.User).Include(x=>x.Post).AsQueryable();
			if (!string.IsNullOrEmpty(search.UserName) || !string.IsNullOrWhiteSpace(search.UserName))
			{
				rates = rates.Where(x => x.User.Username.ToLower().Contains(search.UserName.ToLower()));
			}
			if (search.Mark > 0)
			{
				rates = rates.Where(x => x.Mark==search.Mark);
			}
			if (search.PostId > 0)
			{
				rates = rates.Where(x => x.Post.Id == search.PostId);
			}
			var skipCount = search.PerPage * (search.Page - 1);
			var rate = new PagedResponse<GetRateDto>
			{
				CurrentPage = search.Page,
				PostsPerPage = search.PerPage,
				TotalCount = rates.Count(),
				Items = rates.Skip(skipCount).Take(search.PerPage).Select(c => new GetRateDto
				{
					Id=c.Id,
					Mark=c.Mark,
					PostId=c.PostId,
					UserName=c.User.Username
				})
			};
			return rate;
		}
	}
}
