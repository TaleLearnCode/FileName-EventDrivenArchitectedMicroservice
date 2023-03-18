namespace SLS.CM.Data;

internal static partial class CreateModel
{

	internal static void Employee(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Employee>(entity =>
		{
			entity.ToTable("Employee", "CM");

			entity.Property(e => e.EmployeeId).ValueGeneratedNever();

			entity.Property(e => e.FirstName).HasMaxLength(100);

			entity.Property(e => e.LastName).HasMaxLength(100);

			entity.Property(e => e.RowStatusId).HasDefaultValueSql("((1))");
		});
	}

}