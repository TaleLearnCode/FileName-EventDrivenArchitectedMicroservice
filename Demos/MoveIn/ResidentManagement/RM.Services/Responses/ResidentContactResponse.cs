namespace SLS.RM.Services.Responses;

public class ResidentContactResponse
{
	public int ResidentContactId { get; set; }
	public string? ResidentContactType { get; set; }
	public string? FirstName { get; set; }
	public string? MiddleName { get; set; }
	public string? LastName { get; set; }
	public string? EmailAddress { get; set; }
	public bool HasPowerOfAttorney { get; set; }
	public bool HasDurablePowerOfAttorney { get; set; }
	public bool IsLegalGuardian { get; set; }
	public bool IsMedicalPowerOfAttorney { get; set; }
	public List<PhoneNumberResponse> PhoneNumbers { get; set; } = new();
	public List<PostalAddressResponse> PostalAddresses { get; set; } = new();
}