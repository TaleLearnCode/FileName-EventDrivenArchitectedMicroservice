namespace SLS.CM.Data;

internal static partial class CreateModel
{

	internal static void CareTask(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<CareTask>(entity =>
		{
			entity.HasNoKey();

			entity.ToTable("CareTask", "CM");

			entity.Property(e => e.CareTaskId).ValueGeneratedOnAdd();
		});
	}

}