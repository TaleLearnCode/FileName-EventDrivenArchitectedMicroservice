namespace SLS.PM.Data;

internal static partial class CreateModel
{

	internal static void CommunityAncillaryCare(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<CommunityAncillaryCare>(entity =>
		{
			entity.ToTable("CommunityAncillaryCare", "PM");

			entity.ToTable(tb => tb.IsTemporal(ttb =>
			{
				ttb.UseHistoryTable("CommunityAncillaryCareHistory", "PM");
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

			entity.Property(e => e.ExternalId).HasMaxLength(100);

			entity.HasOne(d => d.AncillaryCare)
					.WithMany(p => p.CommunityAncillaryCares)
					.HasForeignKey(d => d.AncillaryCareId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkCommunityAncillaryCare_AncillaryCare");

			entity.HasOne(d => d.Community)
					.WithMany(p => p.CommunityAncillaryCares)
					.HasForeignKey(d => d.CommunityId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkCommunityAncillaryCare_Community");
		});
	}

}