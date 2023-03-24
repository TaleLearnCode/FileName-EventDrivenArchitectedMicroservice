using Microsoft.EntityFrameworkCore;
using SLS.RM.Domain;

namespace SLS.RM.Data;

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
		});
	}

}