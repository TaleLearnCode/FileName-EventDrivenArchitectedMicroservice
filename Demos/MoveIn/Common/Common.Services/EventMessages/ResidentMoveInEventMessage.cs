namespace SLS.Common.Services.EventMessages;

public class ResidentMoveInEventMessage
{
	public string MessageId { get; set; } = Guid.NewGuid().ToString();
	public int CommunityId { get; set; }
	public MoveInResident? Resident { get; set; }
	public MoveInLease? Lease { get; set; }
	public List<MoveInRoomEventMessage> Rooms { get; set; } = new();
	public MoveInResponsiblePartyEventMessage? ResponsibleParty { get; set; }
}