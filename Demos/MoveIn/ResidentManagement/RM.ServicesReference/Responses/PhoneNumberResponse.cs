namespace SLS.LM.Services.Responses;

public class PhoneNumberResponse
{
	public int PhoneNumberId { get; set; }
	public string? PhoneNumberType { get; set; }
	public bool IsDefault { get; set; }
	public string? CountryCode { get; set; }
	public string? PhoneNumber { get; set; }
}