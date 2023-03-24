using Microsoft.EntityFrameworkCore;
using SLS.RM.Domain;

namespace SLS.RM.Data;

internal static partial class CreateModel
{

	internal static void Community(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Community>(entity =>
		{
			entity.ToTable("Community", "PM");

			entity.HasComment("Represents a community run by the tenant.");

			entity.HasIndex(e => e.CommunityNumber, "idxCommunity_CommunityNumber");

			entity.HasIndex(e => e.CommunityNumber, "unqCommunity_CommunityNumber")
					.IsUnique();

			entity.Property(e => e.CommunityId)
					.ValueGeneratedNever()
					.HasComment("The identifier of the community record.");

			entity.Property(e => e.CommunityName)
					.HasMaxLength(200)
					.HasComment("The name of the community.");

			entity.Property(e => e.CommunityNumber)
					.HasMaxLength(50)
					.HasComment("The tenant's number (identifier) for the community.");

			entity.Property(e => e.ProfileImageUrl)
					.HasMaxLength(500)
					.HasComment("URL of the digital asset that serves as the profile image for the community.");

			entity.Property(e => e.RowStatusId).HasComment("Identifier of the community record status (i.e. enabled, disabled, etc).");

			entity.HasOne(d => d.CommunityStatus)
					.WithMany(p => p.Communities)
					.HasForeignKey(d => d.CommunityStatusId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkCommunity_CommunityStatus");
		});
	}

}