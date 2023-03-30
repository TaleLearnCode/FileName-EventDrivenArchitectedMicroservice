namespace SLS.RM.Services.Responses;

public class ResidentRoomResponse
{
	public int ResidentRoomId { get; set; }
	public int RoomId { get; set; }
	public string? RoomNumber { get; set; }
	public decimal Rate { get; set; }
	public DateTime EffectiveDate { get; set; }
}