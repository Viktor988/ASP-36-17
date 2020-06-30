using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.Queries.Picture
{
	public interface IGetPictureQuery:IQuery<PictureSearch, PagedResponse<GetPictureDto>>
	{
	}
}
