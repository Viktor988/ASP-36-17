using ApiNovine.Application;
using ApiNovine.Application.Commands.Rate;
using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using ApiNovine.Implementation.Validators.Rate;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
namespace ApiNovine.Implementation.Commands.Rate
{
	public class EfCreateRateCommand : ICreateRateCommand
	{
		private readonly ApiNovineContext context;
		private readonly IApplicationActor actor;
		private readonly CreateRateValidator validator;

		public EfCreateRateCommand(ApiNovineContext context, IApplicationActor actor, CreateRateValidator validator)
		{
			this.actor = actor;
			this.context = context;
			this.validator = validator;

		}
		public int Id => 33;

		public string Name => "Insert Rate";

		public void Execute(InsertRateDto request)
		{
			validator.ValidateAndThrow(request);
			var rate = new ApiNovine.Domain.Entities.Rate
			{
				UserId = actor.Id,
				PostId = request.PostId,
				Mark = request.Mark
			};
			context.Rates.Add(rate);
			context.SaveChanges();
		}
	}
}
