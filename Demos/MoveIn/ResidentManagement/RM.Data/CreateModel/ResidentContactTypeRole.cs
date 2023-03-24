using Microsoft.EntityFrameworkCore;
using SLS.RM.Domain;

namespace SLS.RM.Data;

internal static partial class CreateModel
{

	internal static void ResidentContactTypeRole(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ResidentContactTypeRole>(entity =>
		{
			entity.ToTable("ResidentContactTypeRole", "RM");

			entity.Property(e => e.ResidentContactTypeRoleId).ValueGeneratedNever();

			entity.Property(e => e.ResidentContactTypeRoleName).HasMaxLength(100);
		});
	}

}