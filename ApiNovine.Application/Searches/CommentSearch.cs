using ApiNovine.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.Searches
{
	public class CommentSearch: PagedSearch
	{
	
		public string UserName { get; set; }
	}
}
