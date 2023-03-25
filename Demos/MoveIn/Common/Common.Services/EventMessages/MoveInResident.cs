namespace SLS.Common.Services.EventMessages;

public class MoveInResident
{
	public int ResidentId { get; set; }
	public string? FirstName { get; set; }
	public string? MiddleName { get; set; }
	public string? LastName { get; set; }
	public DateTime DateOfBirth { get; set; }
}