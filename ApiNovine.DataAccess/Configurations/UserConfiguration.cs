using ApiNovine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ApiNovine.DataAccess.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasMany(c => c.Comments).WithOne(u => u.User).HasForeignKey(x => x.UserId);
			builder.HasMany(c => c.UserUseCases).WithOne(u => u.User).HasForeignKey(x => x.UserId);
			builder.HasMany(c => c.Rates).WithOne(u => u.User).HasForeignKey(x => x.UserId);
			builder.Property(x => x.Username).IsRequired().HasMaxLength(50);
			builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
			builder.HasIndex(x => x.Username).IsUnique();
			builder.HasIndex(x => x.Email).IsUnique();
			builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
			builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
			builder.Property(x => x.Password).IsRequired().HasMaxLength(50);
		}
	}
}
