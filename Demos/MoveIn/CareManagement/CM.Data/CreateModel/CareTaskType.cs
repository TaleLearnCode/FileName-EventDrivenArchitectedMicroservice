namespace SLS.CM.Data;

internal static partial class CreateModel
{

	internal static void CareTaskType(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<CareTaskType>(entity =>
		{
			entity.ToTable("CareTaskType", "CM");

			entity.Property(e => e.CareTaskTypeName).HasMaxLength(100);

			entity.Property(e => e.RowStatusId).HasDefaultValueSql("((1))");
		});
	}

}