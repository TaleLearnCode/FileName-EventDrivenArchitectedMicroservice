namespace SLS.RM.Services.Requests;

public class MoveInResidentRequest
{
	public string? FirstName { get; set; }
	public string? MiddleName { get; set; }
	public string? LastName { get; set; }
	public DateTime DateOfBirth { get; set; }
}