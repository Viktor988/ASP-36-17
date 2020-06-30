using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.DataTransfer
{
	public class UploadImageDto
	{
		public IFormFile Image { get; set; }
	}
}
