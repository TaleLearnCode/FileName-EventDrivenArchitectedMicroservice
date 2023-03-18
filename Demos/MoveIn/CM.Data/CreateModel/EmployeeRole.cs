namespace SLS.CM.Data;

internal static partial class CreateModel
{

	internal static void EmployeeRole(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<EmployeeRole>(entity =>
		{
			entity.ToTable("EmployeeRole", "CM");

			entity.Property(e => e.EmployeeRoleCode)
					.HasMaxLength(20)
					.IsUnicode(false);

			entity.Property(e => e.EmployeeRoleName).HasMaxLength(100);

			entity.Property(e => e.RowStatusId).HasDefaultValueSql("((1))");
		});
	}

}