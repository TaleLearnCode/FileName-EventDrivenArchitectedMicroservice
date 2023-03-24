namespace SLS.CM.Data;

internal static partial class CreateModel
{

	internal static void CareTaskResident(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<CareTaskResident>(entity =>
		{
			entity.ToTable("CareTaskResident", "CM");

			entity.HasOne(d => d.CareTask)
					.WithMany(p => p.CareTaskResidents)
					.HasForeignKey(d => d.CareTaskId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkCareTaskResident_CareTask");

			entity.HasOne(d => d.Resident)
					.WithMany(p => p.CareTaskResidents)
					.HasForeignKey(d => d.ResidentId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkCareTaskResident_ResidentId");
		});
	}

}