using Microsoft.EntityFrameworkCore;
using SLS.RM.Domain;

namespace SLS.RM.Data;

internal static partial class CreateModel
{

	internal static void CommunityStatus(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<CommunityStatus>(entity =>
		{
			entity.ToTable("CommunityStatus", "PM");

			entity.HasComment("Represents the different statuses for a community.");

			entity.Property(e => e.CommunityStatusId)
					.ValueGeneratedNever()
					.HasComment("The identifier of the community status record.");

			entity.Property(e => e.CommunityStatusName)
					.HasMaxLength(100)
					.HasComment("The name of the community status.");

			entity.Property(e => e.RowStatusId)
					.HasDefaultValueSql("((1))")
					.HasComment("Identifier of the Community Status record status (i.e. enabled, disabled, etc).");

			entity.Property(e => e.SortOrder).HasComment("The sorting order of the Community Status among the other community statuses.");
		});
	}

}