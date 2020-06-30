﻿using ApiNovine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.DataAccess.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasMany(x => x.Posts).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
			builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
		
		}
	}
}
