using SLS.Common.Services.EventMessages;

namespace SLS.CM.Services.Requests;

public class ResidentMoveInRequest
{

	public ResidentMoveInRequest() { }

	public ResidentMoveInRequest(ResidentMoveInEventMessage residentMoveInEventMessage, int roomId)
	{
		ResidentId = residentMoveInEventMessage.Resident?.ResidentId ?? 1;
		CommunityId = residentMoveInEventMessage.CommunityId;
		RoomId = roomId;
		CareTypeId = 3;
		FirstName = residentMoveInEventMessage.Resident?.FirstName ?? string.Empty;
		MiddleName = residentMoveInEventMessage.Resident?.MiddleName;
		LastName = residentMoveInEventMessage.Resident?.LastName ?? string.Empty;
		DateOfBirth = residentMoveInEventMessage.Resident?.DateOfBirth ?? DateTime.MinValue;
	}

	public int ResidentId { get; set; }
	public int CommunityId { get; set; }
	public int RoomId { get; set; }
	public int CareTypeId { get; set; }
	public string FirstName { get; set; } = null!;
	public string? MiddleName { get; set; }
	public string LastName { get; set; } = null!;
	public DateTime DateOfBirth { get; set; }
	public List<int> AncillaryCares { get; set; } = new();
}