namespace SLS.CM.Data;

internal static partial class CreateModel
{

	internal static void Resident(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Resident>(entity =>
		{
			entity.ToTable("Resident", "RM");

			entity.Property(e => e.DateOfBirth).HasColumnType("date");

			entity.Property(e => e.FirstName).HasMaxLength(100);

			entity.Property(e => e.LastName).HasMaxLength(100);

			entity.Property(e => e.MiddleName).HasMaxLength(100);
		});
	}

}