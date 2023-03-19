namespace CM.Services.Responses;

public class ResidentRoomResponse
{
	public int ResidentRoomId { get; set; }
	public string? RoomNumber { get; set; }
	public CareTypeResponse? CareType { get; set; }
}