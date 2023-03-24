using Microsoft.EntityFrameworkCore;
using SLS.RM.Domain;

namespace SLS.RM.Data;

internal static partial class CreateModel
{

	internal static void ResidentContactPhoneNumber(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ResidentContactPhoneNumber>(entity =>
		{
			entity.ToTable("ResidentContactPhoneNumber", "RM");

			entity.Property(e => e.CountryCode)
					.HasMaxLength(10)
					.IsUnicode(false);

			entity.Property(e => e.ExternalId).HasMaxLength(100);

			entity.Property(e => e.PhoneNumber)
					.HasMaxLength(100)
					.IsUnicode(false);

			entity.HasOne(d => d.PhoneNumberType)
					.WithMany(p => p.ResidentContactPhoneNumbers)
					.HasForeignKey(d => d.PhoneNumberTypeId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkContactPhoneNumber_ResidentPhoneNumberType");

			entity.HasOne(d => d.ResidentContact)
					.WithMany(p => p.ResidentContactPhoneNumbers)
					.HasForeignKey(d => d.ResidentContactId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkContactPhoneNumber_Contact");
		});
	}

}