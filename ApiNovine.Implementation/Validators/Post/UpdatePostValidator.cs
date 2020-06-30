using ApiNovine.Application.DataTransfer;
using ApiNovine.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiNovine.Implementation.Validators.Post
{
	public class UpdatePostValidator:AbstractValidator<UpdatePostDto>
	{
		private readonly ApiNovineContext context;
		public UpdatePostValidator(ApiNovineContext context)
		{
			this.context = context;

			RuleFor(x => x.Title).NotEmpty().WithMessage("Title can't be empty")
				.MinimumLength(3).WithMessage("Title must contain more than 3 letters");
			RuleFor(x => x.Content).NotEmpty().WithMessage("Content can't be empty")
				.MinimumLength(5).WithMessage("Content must contain more than 5 letters");
			RuleFor(x => x.CategoryId).Must(CategoryExists).WithMessage("Category with an id of {PropertyValue} doesn't exist.");
			RuleFor(x => x.PictureId).Must(PictureExists).WithMessage("Picture with an id of {PropertyValue} doesn't exist.");
			RuleForEach(x => x.TagPosts).ChildRules(tags =>
			{
				tags.RuleFor(x => x).Must(TagExists)
				.WithMessage("Tag with an id of {PropertyValue} doesn't exist.");
			});
			RuleFor(x => x.TagPosts).Must(c => c.Select(v => v).Distinct().Count() == c.Count())
				.WithMessage("Duplicate tag are not allowed.");


		}
		private bool CategoryExists(int categoryid)
		{
			return context.Categories.Any(x => x.Id == categoryid);
		}

		private bool PictureExists(int PictureId)
		{
			return context.Pictures.Any(x => x.Id == PictureId);
		}
		private bool TagExists(int TagId)
		{
			return context.Tags.Any(x => x.Id == TagId);
		}
	}
}
