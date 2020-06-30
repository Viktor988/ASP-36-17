using ApiNovine.Application.Commands.Rate;
using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Exceptions;
using ApiNovine.DataAccess;
using ApiNovine.Implementation.Validators.Rate;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
namespace ApiNovine.Implementation.Commands.Rate
{
	public class EfUpdateRateCommand : IUpdateRateCommand
	{
		private readonly UpdateRateValidator validator;
		private readonly ApiNovineContext context;


		public EfUpdateRateCommand(ApiNovineContext context, UpdateRateValidator validator)
		{

			this.context = context;
			this.validator = validator;


		}
		public int Id => 38;

		public string Name =>"Update rate";

		public void Execute(UpdateRateDto request)
		{
			validator.ValidateAndThrow(request);
			var rate = context.Rates.Find(request.Id);
			if (rate == null)
			{
				throw new EntityNotFoundException(request.Id, typeof(ApiNovine.Domain.Entities.Rate));
			}
			rate.Mark = request.Mark;
			context.SaveChanges();
			
			

		}
	}
}
