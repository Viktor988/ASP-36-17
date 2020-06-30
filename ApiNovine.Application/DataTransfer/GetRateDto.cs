using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Application.DataTransfer
{
	public class GetRateDto
	{
		public int Id { get; set; }
		public int Mark { get; set; }
		public string UserName { get; set; }
		public int PostId { get; set; }
	}
}
