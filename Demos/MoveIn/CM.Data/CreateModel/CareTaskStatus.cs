namespace SLS.CM.Data;

internal static partial class CreateModel
{

	internal static void CareTaskStatus(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<CareTaskStatus>(entity =>
		{
			entity.ToTable("CareTaskStatus", "CM");

			entity.Property(e => e.CareTaskStatusName).HasMaxLength(100);

			entity.Property(e => e.RowStatusId).HasDefaultValueSql("((1))");
		});
	}

}