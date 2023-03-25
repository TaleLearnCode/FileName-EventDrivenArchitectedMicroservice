namespace SLS.LM.Services.Responses;

public class ResidentAncillaryCareResponse
{
	public int ResidentAncillaryCareId { get; set; }
	public string? AncillaryCareCaregoryName { get; set; }
	public string? AncillaryCareCategoryCode { get; set; }
	public string? AncillaryCareCategoryForegroundColor { get; set; }
	public string? AncillaryCareCategoryBackgroundColor { get; set; }
	public int AncillaryCareId { get; set; }
	public string? AncillaryCareName { get; set; }
	public string? AncillaryCareForegroundColor { get; set; }
	public string? AncillaryCareBackgroundColor { get; set; }
	public decimal Rate { get; set; }
	public DateTime EffectiveDate { get; set; }
}