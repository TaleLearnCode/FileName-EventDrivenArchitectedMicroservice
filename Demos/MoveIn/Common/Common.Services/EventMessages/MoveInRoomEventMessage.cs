namespace SLS.Common.Services.EventMessages;

public class MoveInRoomEventMessage
{
	public int RoomId { get; set; }
	public DateTime EffectiveDate { get; set; }
	public decimal Rate { get; set; }
}