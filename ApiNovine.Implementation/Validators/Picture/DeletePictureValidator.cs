using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Validators.Picture
{
	public class DeletePictureValidator : AbstractValidator<DeletePictureDto>
	{
		private readonly ApiNovineContext context;
		
		public DeletePictureValidator(ApiNovineContext context)
		{
			this.context = context;
			RuleFor(x => x.Id).Must(PictureExist).WithMessage("Post with  PictureId={PropertyValue} Exist");
		}

		public bool PictureExist(int pictureId)
		{
			return !context.Posts.Any(cc => cc.PictureId == pictureId);
		}
	}
}
