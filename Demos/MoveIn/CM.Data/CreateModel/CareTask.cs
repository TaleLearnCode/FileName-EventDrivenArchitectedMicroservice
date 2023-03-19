namespace SLS.CM.Data;

internal static partial class CreateModel
{

	internal static void CareTask(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<CareTask>(entity =>
		{
			entity.ToTable("CareTask", "CM");

			entity.HasOne(d => d.CareTaskStatus)
					.WithMany(p => p.CareTasks)
					.HasForeignKey(d => d.CareTaskStatusId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkCareTask_CareTaskStatus");

			entity.HasOne(d => d.CareTaskType)
					.WithMany(p => p.CareTasks)
					.HasForeignKey(d => d.CareTaskTypeId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkCareTask_CareTaskType");

			entity.HasOne(d => d.PrimaryEmployee)
					.WithMany(p => p.CareTasks)
					.HasForeignKey(d => d.PrimaryEmployeeId)
					.HasConstraintName("fkCareTask_PrimaryEmployee");
		});
	}

}