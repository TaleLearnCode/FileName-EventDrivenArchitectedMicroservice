﻿using Microsoft.EntityFrameworkCore;
using SLS.Core.Domain;

namespace SLS.Core.Data;

internal static partial class CreateModel
{

	internal static void Country(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Country>(entity =>
		{
			entity.HasKey(e => e.CountryCode)
					.HasName("pkcCountry");

			entity.ToTable("Country", "Core");

			entity.HasComment("Lookup table representing the countries as defined by the ISO 3166-1 standard.");

			entity.HasIndex(e => e.WorldRegionCode, "idxCountry_WorldRegionCode");

			entity.HasIndex(e => e.WorldSubregionCode, "idxCountry_WorldSubregionCode");

			entity.Property(e => e.CountryCode)
					.HasMaxLength(2)
					.IsUnicode(false)
					.IsFixedLength()
					.HasComment("Identifier of the country as defined by ISO 3166-1.");

			entity.Property(e => e.CountryName)
					.HasMaxLength(100)
					.IsUnicode(false)
					.HasComment("Name of the country using the ISO 3166-1 Country Name.");

			entity.Property(e => e.DivisionName)
					.HasMaxLength(100)
					.IsUnicode(false)
					.HasComment("The primary name of the country's divisions.");

			entity.Property(e => e.HasDivisions).HasComment("Flag indicating whether the country has divisions (states, provinces, etc.).");

			entity.Property(e => e.RowStatusId).HasComment("Identifier of the status for the record (i.e. enabled, disabled, deleted, etc.).");

			entity.Property(e => e.WorldRegionCode)
					.HasMaxLength(3)
					.IsUnicode(false)
					.IsFixedLength()
					.HasComment("Identifier of the world region where the country is located.");

			entity.Property(e => e.WorldSubregionCode)
					.HasMaxLength(3)
					.IsUnicode(false)
					.IsFixedLength()
					.HasComment("Identifier of the world subregion where the country is located.");

			entity.HasOne(d => d.WorldRegion)
					.WithMany(p => p.CountryWorldRegions)
					.HasForeignKey(d => d.WorldRegionCode)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkCountry_WorldRegion");

			entity.HasOne(d => d.WorldSubregion)
					.WithMany(p => p.CountryWorldSubregions)
					.HasForeignKey(d => d.WorldSubregionCode)
					.HasConstraintName("fkCountry_WorldSubregion");
		});
	}

}