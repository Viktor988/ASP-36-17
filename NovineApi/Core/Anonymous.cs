using ApiNovine.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovineApi.Core
{
	public class Anonymous : IApplicationActor
	{
		public int Id => 0;

		public string Identity => "Anonymus Actor";

		public IEnumerable<int> AllowedUseCases => new List<int> {12,31,1,11 };
	}
}
