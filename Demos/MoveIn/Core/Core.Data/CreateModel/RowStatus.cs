namespace SLS.Core.Data;

internal static partial class CreateModel
{

	internal static void RowStatus(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<RowStatus>(entity =>
		{
			entity.ToTable("RowStatus", "Core");

			entity.HasComment("Represents the status of a record (i.e. enabled, disabled, etc.).");

			entity.Property(e => e.RowStatusId)
					.ValueGeneratedNever()
					.HasComment("Identifier for the row status record.");

			entity.Property(e => e.IsActive).HasComment("Flag indicating whether the row status is active.");

			entity.Property(e => e.IsDisplayed).HasComment("Flag indicating whether the records of the row status are displayed.");

			entity.Property(e => e.RowStatusName)
					.HasMaxLength(100)
					.IsUnicode(false)
					.HasComment("The name of the row status.");
		});
	}

}