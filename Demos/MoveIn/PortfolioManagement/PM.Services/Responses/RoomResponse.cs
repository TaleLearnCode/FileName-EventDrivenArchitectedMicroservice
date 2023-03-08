namespace SLS.PM.Services.Responses;

public class RoomResponse
{

	public int RoomId { get; set; }

	public string RoomNumber { get; set; } = null!;

	public string? RoomName { get; set; }

	public int? RoomArea { get; set; }

	public Uri? Floorplan { get; set; }

	public string CommunityStructure { get; set; } = null!;

	public CommunitySummaryResponse Community { get; set; } = null!;

	public CareTypeResponse? AssignedCareType { get; set; } = null!;

	public IList<CareTypeResponse>? AvailableCareTypes { get; set; } = null!;

	public RoomAvailabilityResponse RoomAvailability { get; set; } = null!;

	public RoomTypeResponse RoomType { get; set; } = null!;

	public IDictionary<string, RoomRateSummaryResponse>? RoomRates { get; set; }

}