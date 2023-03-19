namespace SLS.CM.Services.Responses;

public class ResidentCareTasks
{
	public int ResidentId { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public int ActiveCount { get; set; }
	public List<CareTaskResponse> ActiveCareTasks { get; set; } = new();
}