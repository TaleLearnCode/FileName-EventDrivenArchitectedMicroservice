namespace SLS.CM.Data;

internal static partial class CreateModel
{

	internal static void ResidentAncillaryCare(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ResidentAncillaryCare>(entity =>
		{
			entity.ToTable("ResidentAncillaryCare", "RM");

			entity.ToTable(tb => tb.IsTemporal(ttb =>
			{
				ttb.UseHistoryTable("ResidentAncillaryCareHistory", "RM");
				ttb
						.HasPeriodStart("ValidFrom")
						.HasColumnName("ValidFrom");
				ttb
						.HasPeriodEnd("ValidTo")
						.HasColumnName("ValidTo");
			}
));

			entity.HasOne(d => d.AncillaryCare)
					.WithMany(p => p.ResidentAncillaryCares)
					.HasForeignKey(d => d.AncillaryCareId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkResidentAncillaryCare_AncillaryCare");

			entity.HasOne(d => d.ResidentCommunity)
					.WithMany(p => p.ResidentAncillaryCares)
					.HasForeignKey(d => d.ResidentCommunityId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkResidentAncillaryCare_ResidentCommunity");
		});
	}

}