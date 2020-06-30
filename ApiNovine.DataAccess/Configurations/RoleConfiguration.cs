using ApiNovine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.DataAccess.Configurations
{
	class RoleConfiguration : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.HasMany(c => c.Users).WithOne(x => x.Role).HasForeignKey(x => x.RoleId)
				.OnDelete(DeleteBehavior.Restrict);
			builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
		}

		
	
	}
}
