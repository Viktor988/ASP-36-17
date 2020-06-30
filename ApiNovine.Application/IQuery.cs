using ApiNovine.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application
{
	public interface IQuery<TSearch, TResult> : IUseCase
	{
		TResult Execute(TSearch search);
	}


	
}
