namespace SLS.PM.Services.Responses;

public class RoomAvailabilityResponse
{


	public int Id { get; set; }

	public string Name { get; set; } = null!;

	public string? BackgroundColor { get; set; }

	public string? ForegroundColor { get; set; }

	public bool ShowAsAvailable { get; set; }

	public bool ShowAsReserved { get; set; }

}