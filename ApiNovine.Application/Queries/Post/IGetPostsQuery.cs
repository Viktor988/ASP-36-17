using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.Queries
{
	public interface IGetPostsQuery:IQuery<PostSearch, PagedResponse<GetPostsDto>>
	{
	}
}
