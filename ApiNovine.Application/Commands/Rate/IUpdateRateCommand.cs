using ApiNovine.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.Commands.Rate
{
	public interface IUpdateRateCommand:ICommand<UpdateRateDto>
	{
	}
}
