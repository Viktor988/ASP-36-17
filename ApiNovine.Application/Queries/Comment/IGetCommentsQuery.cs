using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.Queries
{
	public interface IGetCommentsQuery:IQuery<CommentSearch,PagedResponse<CommentsDto>>
	{
	}
}
