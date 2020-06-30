using ApiNovine.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.Email
{
	public interface IEmailSender
	{
		void Send(SendEmailDto dto);
	}
}
