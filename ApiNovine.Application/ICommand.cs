using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application
{
	public interface ICommand<TRequest>:IUseCase
	{
		void Execute(TRequest request);
	}




	
}
