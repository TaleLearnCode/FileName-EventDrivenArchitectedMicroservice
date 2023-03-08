namespace SLS.PM.Services.Responses;

public class CommunitySummaryResponse
{

	public int Id { get; set; }

	public string Number { get; set; } = null!;

	public string Name { get; set; } = null!;

	public string? ExternalName { get; set; }

}