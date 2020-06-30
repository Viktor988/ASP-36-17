using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application
{
	public interface IUseCase
	{
		public int Id { get; }
		public string Name { get; }
	}
}
