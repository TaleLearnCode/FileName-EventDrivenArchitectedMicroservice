namespace SLS.RM.Services.Responses;

public class PostalAddressResponse
{
	public int PostalAddressId { get; set; }
	public string? PostalAddressType { get; set; }
	public string? StreetAddress1 { get; set; }
	public string? StreetAddress2 { get; set; }
	public string? City { get; set; }
	public string? CountryDivision { get; set; }
	public string? Country { get; set; }
	public string? PostalCode { get; set; }
	public bool IsDefault { get; set; }
}