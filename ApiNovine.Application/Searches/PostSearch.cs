using ApiNovine.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.Searches
{
	public class PostSearch:PagedSearch
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime DateFrom { get; set; }
		public DateTime DateTo { get; set; }

		public string OrderBy { get; set; }
		
		
		public int CategoryId { get; set; }
	
	}
}
