namespace SLS.PM.Data;

internal static partial class CreateModel
{

	internal static void AncillaryCare(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<AncillaryCare>(entity =>
		{
			entity.ToTable("AncillaryCare", "PM");

			entity.HasIndex(e => e.ExternalId, "unqAncillaryCare_ExternalId")
					.IsUnique()
					.HasFilter("([ExternalId] IS NOT NULL)");

			entity.Property(e => e.AncillaryCareName).HasMaxLength(100);

			entity.Property(e => e.BackgroundColor)
					.HasMaxLength(7)
					.IsUnicode(false)
					.IsFixedLength();

			entity.Property(e => e.ExternalId).HasMaxLength(100);

			entity.Property(e => e.ForegroundColor)
					.HasMaxLength(7)
					.IsUnicode(false)
					.IsFixedLength();

			entity.Property(e => e.RowStatusId).HasDefaultValueSql("((1))");

			entity.HasOne(d => d.AncillaryCareCategory)
					.WithMany(p => p.AncillaryCares)
					.HasForeignKey(d => d.AncillaryCareCategoryId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkAncillaryCare_AncillaryCareCategory");
		});
	}

}