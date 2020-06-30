using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.Queries.Rate
{
	public interface IGetRatesQuery:IQuery<RateSearch,PagedResponse<GetRateDto>>
	{
	}
}
