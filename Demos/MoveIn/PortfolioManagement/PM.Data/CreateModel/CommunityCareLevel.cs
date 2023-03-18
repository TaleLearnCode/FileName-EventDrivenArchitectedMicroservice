namespace SLS.PM.Data;

internal static partial class CreateModel
{

	internal static void CommunityCareLevel(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<CommunityCareLevel>(entity =>
		{
			entity.ToTable("CommunityCareLevel", "PM");

			entity.ToTable(tb => tb.IsTemporal(ttb =>
			{
				ttb.UseHistoryTable("CommunityCareLevelHistory", "PM");
				ttb
						.HasPeriodStart("ValidFrom")
						.HasColumnName("ValidFrom");
				ttb
						.HasPeriodEnd("ValidTo")
						.HasColumnName("ValidTo");
			}
));

			entity.Property(e => e.BaseRate).HasColumnType("smallmoney");

			entity.Property(e => e.DailyRate).HasColumnType("smallmoney");

			entity.HasOne(d => d.CareLevel)
					.WithMany(p => p.CommunityCareLevels)
					.HasForeignKey(d => d.CareLevelId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkCommunityCareLevel_CareLevel");

			entity.HasOne(d => d.Community)
					.WithMany(p => p.CommunityCareLevels)
					.HasForeignKey(d => d.CommunityId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkCommunityCareLevel_Community");
		});

	}

}