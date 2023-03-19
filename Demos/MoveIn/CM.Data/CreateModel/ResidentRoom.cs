namespace SLS.CM.Data;

internal static partial class CreateModel
{

	internal static void ResidentRoom(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ResidentRoom>(entity =>
		{
			entity.ToTable("ResidentRoom", "RM");

			entity.ToTable(tb => tb.IsTemporal(ttb =>
			{
				ttb.UseHistoryTable("ResidentRoomHistory", "PM");
				ttb
						.HasPeriodStart("ValidFrom")
						.HasColumnName("ValidFrom");
				ttb
						.HasPeriodEnd("ValidTo")
						.HasColumnName("ValidTo");
			}
));

			entity.HasOne(d => d.CareType)
					.WithMany(p => p.ResidentRooms)
					.HasForeignKey(d => d.CareTypeId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkResidentRoom_CareType");

			entity.HasOne(d => d.ResidentCommunity)
					.WithMany(p => p.ResidentRooms)
					.HasForeignKey(d => d.ResidentCommunityId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkResidentRoom_ResidentCommunity");

			entity.HasOne(d => d.Room)
					.WithMany(p => p.ResidentRooms)
					.HasForeignKey(d => d.RoomId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkResidentRoom_Room");
		});
	}

}