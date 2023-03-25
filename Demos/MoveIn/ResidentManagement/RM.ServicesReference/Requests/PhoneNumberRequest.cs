namespace SLS.RM.Services.Requests;

public class PhoneNumberRequest
{
	public int PhoneNumberTypeId { get; set; }
	public string? CountryCode { get; set; }
	public string? PhoneNumber { get; set; }
	public bool IsDefault { get; set; } = false;
}