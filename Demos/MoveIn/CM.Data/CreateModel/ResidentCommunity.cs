namespace SLS.CM.Data;

internal static partial class CreateModel
{

	internal static void ResidentCommunity(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ResidentCommunity>(entity =>
		{
			entity.ToTable("ResidentCommunity", "RM");

			entity.ToTable(tb => tb.IsTemporal(ttb =>
			{
				ttb.UseHistoryTable("ResidentCommunityHistory", "RM");
				ttb
						.HasPeriodStart("ValidFrom")
						.HasColumnName("ValidFrom");
				ttb
						.HasPeriodEnd("ValidTo")
						.HasColumnName("ValidTo");
			}
));

			entity.HasOne(d => d.Community)
					.WithMany(p => p.ResidentCommunities)
					.HasForeignKey(d => d.CommunityId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkResidentCommunity_Community");

			entity.HasOne(d => d.Resident)
					.WithMany(p => p.ResidentCommunities)
					.HasForeignKey(d => d.ResidentId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkResidentCommunity_Resident");
		});
	}

}