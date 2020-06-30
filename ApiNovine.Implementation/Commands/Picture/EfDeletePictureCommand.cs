using ApiNovine.Application.Commands.Picture;
using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using ApiNovine.Implementation.Validators.Picture;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ApiNovine.Application.Exceptions;
using ApiNovine.Domain.Entities;

namespace ApiNovine.Implementation.Commands.Picture
{
	public class EfDeletePictureCommand : IDeletePictureCommand
	{
		private readonly ApiNovineContext context;
		private readonly DeletePictureValidator validator;
		public EfDeletePictureCommand(ApiNovineContext context, DeletePictureValidator validator)
		{
			this.context = context;
			this.validator = validator;
	
		}
		public int Id => 10;

		public string Name => "Delete picture";

		public void Execute(DeletePictureDto request)
		{
			validator.ValidateAndThrow(request);
			
			var picture = context.Pictures.Find(request.Id);
			if (picture == null)
			{
				throw new EntityNotFoundException(request.Id, typeof(ApiNovine.Domain.Entities.Picture));
			}
			picture.DeletedAt = DateTime.Now;
			picture.IsDeleted = true;
			picture.IsActive = false;
			context.SaveChanges();
		}
	}
}
