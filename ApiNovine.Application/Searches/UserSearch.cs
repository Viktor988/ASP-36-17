using ApiNovine.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.Searches
{
	public class UserSearch:PagedSearch
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string RoleName { get; set; }
	}
}
