namespace SLS.PM.Data;

internal static partial class CreateModel
{

	internal static void DigitalAssetType(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<DigitalAssetType>(entity =>
		{
			entity.ToTable("DigitalAssetType", "DCM");

			entity.HasComment("Defines the types of digital asset locations supported by the system.");

			entity.Property(e => e.DigitalAssetTypeId)
					.ValueGeneratedNever()
					.HasComment("Identifier of the Digital Asset Type record.");

			entity.Property(e => e.DigitalAssetTypeName)
					.HasMaxLength(100)
					.IsUnicode(false)
					.HasComment("The name of the Digital Asset Type.");

			entity.Property(e => e.Discriminator)
					.HasMaxLength(20)
					.IsUnicode(false)
					.HasComment("The discriminator used when saving the different digital asset types.");

			entity.Property(e => e.RowStatusId).HasComment("Identifier of the record status (i.e. enabled, disabled, deleted, etc.).");

			entity.Property(e => e.SortOrder).HasComment("Sorting order of the Digital Asset Type.");
		});
	}

}