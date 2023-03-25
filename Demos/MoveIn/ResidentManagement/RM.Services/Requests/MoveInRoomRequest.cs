namespace SLS.LM.Services.Requests;

public class MoveInRoomRequest
{
	public int RoomId { get; set; }
	public DateTime EffectiveDate { get; set; }
	public decimal Rate { get; set; }
}