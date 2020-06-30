using System;
using System.Collections.Generic;
using System.Text;
using ApiNovine.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiNovine.DataAccess.Configurations
{
	class RateConfiguration : IEntityTypeConfiguration<Rate>
	{
		public void Configure(EntityTypeBuilder<Rate> builder)
		{
			builder.HasOne(x => x.User).WithMany(x => x.Rates).HasForeignKey(x => x.UserId);
			builder.HasOne(x => x.Post).WithMany(x => x.Rates).HasForeignKey(x => x.PostId);
			builder.Property(x => x.Mark).IsRequired().HasMaxLength(3);
		}
	}
}
