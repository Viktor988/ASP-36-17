﻿using ApiNovine.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.Queries
{
	public interface IGetUserQuery:IQuery<int,UserDto>
	{
	}
}
