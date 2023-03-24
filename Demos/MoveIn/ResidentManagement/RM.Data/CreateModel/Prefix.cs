using Microsoft.EntityFrameworkCore;
using SLS.RM.Domain;

namespace SLS.RM.Data;

internal static partial class CreateModel
{

	internal static void Prefix(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Prefix>(entity =>
		{
			entity.ToTable("Prefix", "Core");

			entity.Property(e => e.PrefixId).ValueGeneratedNever();

			entity.Property(e => e.PrefixValue).HasMaxLength(100);
		});
	}

}