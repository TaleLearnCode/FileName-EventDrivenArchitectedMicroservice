using Microsoft.EntityFrameworkCore;
using SLS.RM.Domain;

namespace SLS.RM.Data;

internal static partial class CreateModel
{

	internal static void ResidentCareLevel(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ResidentCareLevel>(entity =>
		{
			entity.ToTable("ResidentCareLevel", "RM");

			entity.ToTable(tb => tb.IsTemporal(ttb =>
			{
				ttb.UseHistoryTable("ResidentCareLevelHistory", "RM");
				ttb
						.HasPeriodStart("ValidFrom")
						.HasColumnName("ValidFrom");
				ttb
						.HasPeriodEnd("ValidTo")
						.HasColumnName("ValidTo");
			}
));

			entity.Property(e => e.EffectiveDate)
					.HasColumnType("date")
					.HasDefaultValueSql("(getutcdate())");

			entity.Property(e => e.Rate).HasColumnType("smallmoney");

			entity.HasOne(d => d.CareLevel)
					.WithMany(p => p.ResidentCareLevels)
					.HasForeignKey(d => d.CareLevelId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkResidentCareLevel_CareLevel");

			entity.HasOne(d => d.ResidentCommunity)
					.WithMany(p => p.ResidentCareLevels)
					.HasForeignKey(d => d.ResidentCommunityId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkResidentCareLevel_ResidentCommunityId");
		});
	}

}