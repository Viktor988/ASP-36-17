using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries;
using ApiNovine.Application.Searches;
using ApiNovine.DataAccess;
using ApiNovine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Queries
{
	public class EfGetTagsQuery : IGetTagsQuery
	{
		private readonly ApiNovineContext _context;
		public EfGetTagsQuery(ApiNovineContext context)
		{
			_context = context;
		}
		public int Id => 21;

		public string Name => "Get Tags";

		public PagedResponse<TagDto> Execute(TagSearch search)
		{
			var tags = _context.Tags.AsQueryable();
			if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
			{
				tags = tags.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
			}
			var skipCount = search.PerPage * (search.Page - 1);
			var tag = new PagedResponse<TagDto>
			{
				CurrentPage = search.Page,
				PostsPerPage = search.PerPage,
				TotalCount = tags.Count(),
				Items = tags.Skip(skipCount).Take(search.PerPage).Select(c => new TagDto
				{
					Id = c.Id,
					Name = c.Name
				})
			};
			return tag;
		}
	}
}
