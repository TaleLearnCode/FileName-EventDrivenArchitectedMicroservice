namespace SLS.RM.Domain;

/// <summary>
/// Represents a room within a community.
/// </summary>
public partial class Room
{
	public Room()
	{
		ResidentRooms = new HashSet<ResidentRoom>();
	}

	/// <summary>
	/// Identifier of the room record.
	/// </summary>
	public int RoomId { get; set; }
	/// <summary>
	/// Identifier of the associated community record.
	/// </summary>
	public int CommunityId { get; set; }
	/// <summary>
	/// The number of the room.
	/// </summary>
	public string RoomNumber { get; set; } = null!;

	public virtual Community Community { get; set; } = null!;
	public virtual ICollection<ResidentRoom> ResidentRooms { get; set; }
}
