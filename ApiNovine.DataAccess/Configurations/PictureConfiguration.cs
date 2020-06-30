using ApiNovine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.DataAccess.Configurations
{
	public class PictureConfiguration : IEntityTypeConfiguration<Picture>
	{
		public void Configure(EntityTypeBuilder<Picture> builder)
		{
			builder.HasMany(c => c.Posts).WithOne(x => x.Picture).HasForeignKey(x => x.PictureId)
				.OnDelete(DeleteBehavior.Restrict);
			builder.Property(x => x.Src).IsRequired();
		}
	}
}
