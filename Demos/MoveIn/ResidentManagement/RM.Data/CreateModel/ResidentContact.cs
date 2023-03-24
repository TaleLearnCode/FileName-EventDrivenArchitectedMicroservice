using Microsoft.EntityFrameworkCore;
using SLS.RM.Domain;

namespace SLS.RM.Data;

internal static partial class CreateModel
{

	internal static void ResidentContact(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ResidentContact>(entity =>
		{
			entity.ToTable("ResidentContact", "RM");

			entity.Property(e => e.EmailAddress).HasMaxLength(200);

			entity.Property(e => e.ExternalId).HasMaxLength(100);

			entity.Property(e => e.FirstName).HasMaxLength(100);

			entity.Property(e => e.LastName).HasMaxLength(100);

			entity.Property(e => e.MiddleName).HasMaxLength(100);

			entity.HasOne(d => d.ResidentContactType)
					.WithMany(p => p.ResidentContacts)
					.HasForeignKey(d => d.ResidentContactTypeId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkResidentContact_ContactType");

			entity.HasOne(d => d.Resident)
					.WithMany(p => p.ResidentContacts)
					.HasForeignKey(d => d.ResidentId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkResidentContact_Resident");
		});
	}

}