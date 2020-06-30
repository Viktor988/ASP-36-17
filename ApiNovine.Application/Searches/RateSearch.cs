using ApiNovine.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.Searches
{
	public class RateSearch:PagedSearch
	{
		public int Mark { get; set; }
		public string UserName { get; set; }
		public int PostId { get; set; }
	}
}
