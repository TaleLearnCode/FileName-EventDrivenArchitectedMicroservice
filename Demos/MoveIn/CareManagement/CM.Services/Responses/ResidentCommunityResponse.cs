namespace SLS.CM.Services.Responses;

public class ResidentCommunityResponse
{
	public int ResidentCommunityId { get; set; }
	public string? CommunityNumber { get; set; }
	public string? CommunityName { get; set; }
	public Uri? ProfileImageUrl { get; set; }
	public List<ResidentRoomResponse>? Rooms { get; set; }
	public List<AncillaryCareResponse>? AncillaryCares { get; set; }
}