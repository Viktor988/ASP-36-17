using ApiNovine.Application.Commands.Rate;
using ApiNovine.Application.Exceptions;
using ApiNovine.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Implementation.Commands.Rate
{
	public class EfDeleteRateCommand : IDeleteRateCommand
	{
		private readonly ApiNovineContext context;
		public EfDeleteRateCommand(ApiNovineContext context)
		{
			this.context = context;
		}
		public int Id => 37;

		public string Name => "Delete Rate";

		public void Execute(int request)
		{
			var rate = context.Rates.Find(request);
			if (rate == null)
			{
				throw new EntityNotFoundException(request, typeof(ApiNovine.Domain.Entities.Rate));
			}
			rate.DeletedAt = DateTime.Now;
			rate.IsDeleted = true;
			rate.IsActive = false;
			context.SaveChanges();
		}
	}
}
