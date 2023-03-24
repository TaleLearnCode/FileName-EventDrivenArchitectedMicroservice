using Microsoft.EntityFrameworkCore;
using SLS.RM.Domain;

namespace SLS.RM.Data;

internal static partial class CreateModel
{

	internal static void Room(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Room>(entity =>
		{
			entity.ToTable("Room", "PM");

			entity.HasComment("Represents a room within a community.");

			entity.HasIndex(e => e.CommunityId, "idxRoom_CommunityId");

			entity.Property(e => e.RoomId)
					.ValueGeneratedNever()
					.HasComment("Identifier of the room record.");

			entity.Property(e => e.CommunityId).HasComment("Identifier of the associated community record.");

			entity.Property(e => e.RoomNumber)
					.HasMaxLength(100)
					.HasComment("The number of the room.");

			entity.HasOne(d => d.Community)
					.WithMany(p => p.Rooms)
					.HasForeignKey(d => d.CommunityId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkRoom_Community");
		});
	}

}