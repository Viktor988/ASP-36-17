using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Exceptions;
using ApiNovine.Application.Queries.Rate;
using ApiNovine.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Queries.Rate
{
	public class EfGetRateQuery : IGetRateQuery
	{
		private readonly ApiNovineContext _context;
		public EfGetRateQuery(ApiNovineContext context)
		{
			_context = context;
		}
		public int Id =>39;

		public string Name => "Get rate";

		public GetRateDto Execute(int search)
		{
			var rate = _context.Rates.Include(x => x.User).FirstOrDefault(x=>x.Id==search);
			if (rate == null)
			{
				throw new EntityNotFoundException(search, typeof(ApiNovine.Domain.Entities.Rate));
			}
			return new GetRateDto
			{
				Id = rate.Id,
				Mark = rate.Mark,
				PostId = rate.PostId,
				UserName = rate.User.Username
			};
		}
	}
}
