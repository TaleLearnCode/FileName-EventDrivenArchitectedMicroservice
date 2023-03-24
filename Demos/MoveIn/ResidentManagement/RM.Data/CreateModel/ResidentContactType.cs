using Microsoft.EntityFrameworkCore;
using SLS.RM.Domain;

namespace SLS.RM.Data;

internal static partial class CreateModel
{

	internal static void ResidentContactType(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ResidentContactType>(entity =>
		{
			entity.ToTable("ResidentContactType", "RM");

			entity.Property(e => e.ResidentContactTypeId).ValueGeneratedNever();

			entity.Property(e => e.ExternalId).HasMaxLength(100);

			entity.Property(e => e.ResidentContactTypeName).HasMaxLength(100);

			entity.HasOne(d => d.ResidentContactTypeRole)
					.WithMany(p => p.ResidentContactTypes)
					.HasForeignKey(d => d.ResidentContactTypeRoleId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkResidentContactType_ContactTypeRole");
		});
	}

}