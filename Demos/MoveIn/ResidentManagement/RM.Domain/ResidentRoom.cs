namespace SLS.RM.Domain;

public partial class ResidentRoom
{
	public int ResidentRoomId { get; set; }
	public int ResidentCommunityId { get; set; }
	public int RoomId { get; set; }
	public decimal Rate { get; set; }
	public DateTime EffectiveDate { get; set; }

	public virtual Room Room { get; set; } = null!;
	public virtual ResidentCommunity ResidentCommunity { get; set; } = null!;
}
