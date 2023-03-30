namespace SLS.RM.Services.Responses;

public class ResidentCommunityResponse
{
	public int ResidentCommunityId { get; set; }
	public string? CommunityNumber { get; set; }
	public string? CommunityName { get; set; }
	public LeaseResponse? Lease { get; set; }
	public List<ResidentRoomResponse> Rooms { get; set; } = new();
	public ResidentCareTypeResponse? CareType { get; set; }
	public Dictionary<string, List<ResidentAncillaryCareResponse>> AncillaryCares { get; set; } = new();
}