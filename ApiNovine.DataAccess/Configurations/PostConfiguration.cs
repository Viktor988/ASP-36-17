using ApiNovine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.DataAccess.Configurations
{
	public class PostConfiguration : IEntityTypeConfiguration<Post>
	{
		public void Configure(EntityTypeBuilder<Post> builder)
		{
			builder.HasMany(c => c.Comments).WithOne(x => x.Post).HasForeignKey(c => c.PostId);
			builder.HasMany(c => c.TagPosts).WithOne(x => x.Post).HasForeignKey(c => c.PostId);
			builder.HasMany(c => c.Rates).WithOne(x => x.Post).HasForeignKey(c => c.PostId);
			builder.Property(x => x.Title).IsRequired();
			builder.Property(x => x.Content).IsRequired();
			builder.Property(x => x.CategoryId).IsRequired();
			builder.Property(x => x.PictureId).IsRequired();

		}
	}
}
