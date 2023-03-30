namespace SLS.RM.Services.Requests;

public class MoveInResponsiblePartyRequest
{
	public string? FirstName { get; set; }
	public string? MiddleName { get; set; }
	public string? LastName { get; set; }
	public string? EmailAddress { get; set; }
	public PostalAddressRequest? PostalAddress { get; set; }
	public PhoneNumberRequest? PhoneNumber { get; set; }
	public bool HasPowerOfAttorney { get; set; } = false;
	public bool HasDurablePowerOfAttorney { get; set; } = false;
	public bool IsLegalGuardian { get; set; } = false;
	public bool IsMedicalPowerOfAttorney { get; set; } = false;
}