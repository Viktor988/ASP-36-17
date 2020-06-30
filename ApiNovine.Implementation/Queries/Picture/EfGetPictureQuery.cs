using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries;
using ApiNovine.Application.Queries.Picture;
using ApiNovine.Application.Searches;
using ApiNovine.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Queries.Picture
{
	public class EfGetPictureQuery : IGetPictureQuery
	{
		private readonly ApiNovineContext _context;
		public EfGetPictureQuery(ApiNovineContext context)
		{
			_context = context;
		}
		public int Id => 9;

		public string Name => "Get picture";

		public PagedResponse<GetPictureDto> Execute(PictureSearch search)
		{
			var pictures = _context.Pictures.AsQueryable();
			if (!string.IsNullOrEmpty(search.Src) || !string.IsNullOrWhiteSpace(search.Src))
			{
				pictures = pictures.Where(x => x.Src.ToLower().Contains(search.Src.ToLower()));
			}

			var skipCount = search.PerPage * (search.Page - 1);
			var picture = new PagedResponse<GetPictureDto>
			{
				CurrentPage = search.Page,
				PostsPerPage = search.PerPage,
				TotalCount = pictures.Count(),
				Items = pictures.Skip(skipCount).Take(search.PerPage).Select(c => new GetPictureDto
				{
					Id = c.Id,
					Src = c.Src
				}).ToList()
			};
			return picture;
		} 

	}
}
