namespace SLS.RM.Services.Requests;

public class MoveInRequest
{
	public int CommunityId { get; set; }
	public MoveInResidentRequest? Resident { get; set; }
	public MoveInLeaseRequest? Lease { get; set; }
	public List<MoveInRoomRequest> Rooms { get; set; } = new();
	public MoveInResponsiblePartyRequest? ResponsibleParty { get; set; }
}