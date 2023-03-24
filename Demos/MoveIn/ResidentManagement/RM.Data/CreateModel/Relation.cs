using Microsoft.EntityFrameworkCore;
using SLS.RM.Domain;

namespace SLS.RM.Data;

internal static partial class CreateModel
{

	internal static void Relation(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Relation>(entity =>
		{
			entity.ToTable("Relation", "RM");

			entity.Property(e => e.RelationId).ValueGeneratedNever();

			entity.Property(e => e.RelationName).HasMaxLength(100);
		});
	}

}