using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Exceptions;
using ApiNovine.Application.Queries;
using ApiNovine.DataAccess;
using ApiNovine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Implementation.Queries
{
	public class EfGetTagQuery : IGetTagQuery
	{
		private readonly ApiNovineContext _context;
		public EfGetTagQuery(ApiNovineContext context)
		{
			_context = context;
		}
		public int Id => 22;

		public string Name => "Get tag";

		public TagDto Execute(int search)
		{
			var tag = _context.Tags.Find(search);
			if (tag == null)
			{
				throw new EntityNotFoundException(search, typeof(ApiNovine.Domain.Entities.Tag));
			}

			return new TagDto
			{
				Id = tag.Id,
				Name = tag.Name
			};

		}
	}
}
