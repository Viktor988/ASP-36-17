using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application
{
	public interface IUseCaseLogger
	{
		void Log(IUseCase userCase, IApplicationActor actor, object useCaseData);
	}
}
