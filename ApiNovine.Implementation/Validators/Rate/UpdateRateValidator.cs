using System;
using System.Collections.Generic;
using System.Text;
using ApiNovine.Application.DataTransfer;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
namespace ApiNovine.Implementation.Validators.Rate
{
	public class UpdateRateValidator:AbstractValidator<UpdateRateDto>
	{
		public UpdateRateValidator()
		{
			RuleFor(x => x.Mark).NotEmpty().WithMessage("Mark is required").GreaterThan(0).LessThan(6);
		}
	}
}
