namespace SLS.Common.Services.EventMessages;

public class MoveInLease
{
	public int LeaseTypeId { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public string? LesseeFirstName { get; set; }
	public string? LesseeMiddleName { get; set; }
	public string? LesseeLastName { get; set; }
	public string? LesseeEmail { get; set; }
	public PostalAddressEventMessage? PostalAddress { get; set; }
	public PhoneNumberEventMessage? PhoneNumber { get; set; }
}