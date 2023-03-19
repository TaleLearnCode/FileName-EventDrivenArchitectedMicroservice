namespace SLS.CM.Services.Responses;

public class ResidentResponse
{
	public int ResidentId { get; set; }
	public string? FirstName { get; set; }
	public string? MiddleName { get; set; }
	public string? LastName { get; set; }
	public DateTime DateOfBirth { get; set; }
	public List<ResidentCommunityResponse>? Communities { get; set; }
}