using Microsoft.EntityFrameworkCore;
using SLS.RM.Domain;

namespace SLS.RM.Data;

internal static partial class CreateModel
{

	internal static void CareLevel(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<CareLevel>(entity =>
		{
			entity.ToTable("CareLevel", "PM");

			entity.Property(e => e.CareLevelId).ValueGeneratedNever();

			entity.Property(e => e.CareLevelName).HasMaxLength(100);

			entity.HasOne(d => d.CareType)
					.WithMany(p => p.CareLevels)
					.HasForeignKey(d => d.CareTypeId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkCareLevel_CareType");
		});
	}

}