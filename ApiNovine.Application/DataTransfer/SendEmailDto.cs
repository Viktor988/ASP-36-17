﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.DataTransfer
{
	public class SendEmailDto
	{
		public string Content { get; set; }
		public string Subject { get; set; }

		public string SendTo { get; set; }
	}
}
