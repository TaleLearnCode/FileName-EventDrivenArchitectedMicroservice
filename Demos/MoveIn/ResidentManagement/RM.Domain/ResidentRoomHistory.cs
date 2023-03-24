namespace SLS.RM.Domain;

public partial class ResidentRoomHistory
{
	public int ResidentRoomId { get; set; }
	public int ResidentCommunityId { get; set; }
	public int RoomId { get; set; }
	public decimal Rate { get; set; }
	public DateTime EffectiveDate { get; set; }
	public DateTime ValidFrom { get; set; }
	public DateTime ValidTo { get; set; }
}
