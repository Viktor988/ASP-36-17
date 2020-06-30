using ApiNovine.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.Searches
{
	public class TagSearch:PagedSearch
	{
		public string Name { get; set; }
	}
}
