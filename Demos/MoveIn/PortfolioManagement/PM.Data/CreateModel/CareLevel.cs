namespace SLS.PM.Data;

internal static partial class CreateModel
{

	internal static void CareLevel(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<CareLevel>(entity =>
		{
			entity.ToTable("CareLevel", "PM");

			entity.HasIndex(e => e.ExternalId, "unqCareLevel_ExternalId")
					.IsUnique()
					.HasFilter("([ExternalId] IS NOT NULL)");

			entity.Property(e => e.CareLevelId).ValueGeneratedNever();

			entity.Property(e => e.AssignToNewCommunities)
					.IsRequired()
					.HasDefaultValueSql("((1))");

			entity.Property(e => e.CareLevelName).HasMaxLength(100);

			entity.Property(e => e.ExternalId).HasMaxLength(100);

			entity.HasOne(d => d.CareType)
					.WithMany(p => p.CareLevels)
					.HasForeignKey(d => d.CareTypeId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkCareLevel_CareType");
		});
	}

}