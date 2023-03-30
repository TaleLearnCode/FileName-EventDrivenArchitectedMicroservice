namespace SLS.RM.Services.Requests;

public class MoveInLeaseRequest
{
	public int LeaseTypeId { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public string? LesseeFirstName { get; set; }
	public string? LesseeMiddleName { get; set; }
	public string? LesseeLastName { get; set; }
	public string? LesseeEmail { get; set; }
	public PostalAddressRequest? PostalAddress { get; set; }
	public PhoneNumberRequest? PhoneNumber { get; set; }
}