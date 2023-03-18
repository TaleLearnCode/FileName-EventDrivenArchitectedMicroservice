namespace SLS.PM.Data;

internal static partial class CreateModel
{

	internal static void AncillaryCareCategory(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<AncillaryCareCategory>(entity =>
		{
			entity.ToTable("AncillaryCareCategory", "PM");

			entity.HasIndex(e => e.ExternalId, "unqAncillaryCareCategory_ExternalId")
					.IsUnique()
					.HasFilter("([ExternalId] IS NOT NULL)");

			entity.Property(e => e.AncillaryCareCategoryCode).HasMaxLength(20);

			entity.Property(e => e.AncillaryCareCategoryName).HasMaxLength(100);

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
		});
	}

}