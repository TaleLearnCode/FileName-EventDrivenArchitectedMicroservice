namespace CM.Services.Requests;

public class ResidentMoveInRequest
{
	public int ResidentId { get; set; }
	public int CommunityId { get; set; }
	public int RoomId { get; set; }
	public int CareTypeId { get; set; }
	public string FirstName { get; set; } = null!;
	public string? MiddleName { get; set; }
	public string LastName { get; set; } = null!;
	public DateOnly DateOfBirth { get; set; }
	public List<int> AncillaryCares { get; set; } = new();
}