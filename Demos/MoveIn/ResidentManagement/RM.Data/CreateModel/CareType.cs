﻿using Microsoft.EntityFrameworkCore;
using SLS.RM.Domain;

namespace SLS.RM.Data;

internal static partial class CreateModel
{

	internal static void CareType(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<CareType>(entity =>
		{
			entity.ToTable("CareType", "PM");

			entity.HasComment("Represents a type of care provided by a community.");

			entity.Property(e => e.CareTypeId).HasComment("Identifier for the care type record.");

			entity.Property(e => e.BackgroundColor)
					.HasMaxLength(6)
					.IsUnicode(false)
					.IsFixedLength()
					.HasComment("The background color to use when displaying the care type within the Glennis suite of products.");

			entity.Property(e => e.CareTypeCode)
					.HasMaxLength(20)
					.HasComment("The code assigned to the care type.");

			entity.Property(e => e.CareTypeName)
					.HasMaxLength(100)
					.HasComment("The name of the care type.");

			entity.Property(e => e.ForegroundColor)
					.HasMaxLength(6)
					.IsUnicode(false)
					.IsFixedLength()
					.HasComment("The foreground color to use when displaying the care type within the Glennis suite of products.");
		});
	}

}