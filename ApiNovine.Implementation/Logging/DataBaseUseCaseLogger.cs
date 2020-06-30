using ApiNovine.Application;
using ApiNovine.DataAccess;
using ApiNovine.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Implementation.Logging
{
	public class DataBaseUseCaseLogger : IUseCaseLogger
	{
		private readonly ApiNovineContext context;

		public DataBaseUseCaseLogger(ApiNovineContext context)
		{
			this.context = context;

		}
		public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
		{
			context.UseCaseLogs.Add(new UseCaseLog
			{
				Actor = actor.Identity,
				Data = JsonConvert.SerializeObject(useCaseData),
				Date = DateTime.UtcNow,
				UseCaseName=useCase.Name
			});
			context.SaveChanges();
		}
	}
}
