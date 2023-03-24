using Microsoft.EntityFrameworkCore;
using SLS.RM.Domain;

namespace SLS.RM.Data;

internal static partial class CreateModel
{

	internal static void ResidentContactPostalAddress(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ResidentContactPostalAddress>(entity =>
		{
			entity.ToTable("ResidentContactPostalAddress", "PM");

			entity.Property(e => e.City).HasMaxLength(100);

			entity.Property(e => e.CountryCode)
					.HasMaxLength(2)
					.IsUnicode(false)
					.IsFixedLength();

			entity.Property(e => e.CountryDivisionCode)
					.HasMaxLength(3)
					.IsUnicode(false)
					.IsFixedLength();

			entity.Property(e => e.ExternalId).HasMaxLength(100);

			entity.Property(e => e.PostalCode).HasMaxLength(20);

			entity.Property(e => e.StreetAddress1).HasMaxLength(100);

			entity.Property(e => e.StreetAddress2).HasMaxLength(100);

			entity.HasOne(d => d.CountryCodeNavigation)
					.WithMany(p => p.ResidentContactPostalAddresses)
					.HasForeignKey(d => d.CountryCode)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkCommunityPostalAddress_Country");

			entity.HasOne(d => d.PostalAddressType)
					.WithMany(p => p.ResidentContactPostalAddresses)
					.HasForeignKey(d => d.PostalAddressTypeId)
					.HasConstraintName("fkCommunityPostalAddress_ResidentPostalAddressType");

			entity.HasOne(d => d.ResidentContact)
					.WithMany(p => p.ResidentContactPostalAddresses)
					.HasForeignKey(d => d.ResidentContactId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkCommunityPostalAddress_Contact");

			entity.HasOne(d => d.Country)
					.WithMany(p => p.ResidentContactPostalAddresses)
					.HasForeignKey(d => new { d.CountryCode, d.CountryDivisionCode })
					.HasConstraintName("fkCommunityPostalAddress_CountryDivision");
		});
	}

}