namespace SLS.LM.Services.Responses;

public class ResidentCareTypeResponse
{
	public int ResidentCareTypeId { get; set; }
	public string? CareTypeName { get; set; }
	public string? CareTypeCode { get; set; }
	public string? ForegroundColor { get; set; }
	public string? BackgroundColor { get; set; }
	public decimal Rate { get; set; }
	public DateTime EffectiveDate { get; set; }
}