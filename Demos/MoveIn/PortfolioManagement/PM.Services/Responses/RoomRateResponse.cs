namespace SLS.PM.Services.Responses;

public class RoomRateSummaryResponse
{

	public int PayorTypeId { get; set; }

	public string PayorTypeName { get; set; } = null!;

	public decimal MonthlyRate { get; set; }

	public decimal? DailyRate { get; set; }


}