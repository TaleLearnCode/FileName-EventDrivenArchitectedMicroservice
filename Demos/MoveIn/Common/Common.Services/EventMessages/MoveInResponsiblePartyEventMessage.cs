namespace SLS.Common.Services.EventMessages;

public class MoveInResponsiblePartyEventMessage
{
	public string? FirstName { get; set; }
	public string? MiddleName { get; set; }
	public string? LastName { get; set; }
	public string? EmailAddress { get; set; }
	public PostalAddressEventMessage? PostalAddress { get; set; }
	public PhoneNumberEventMessage? PhoneNumber { get; set; }
	public bool HasPowerOfAttorney { get; set; } = false;
	public bool HasDurablePowerOfAttorney { get; set; } = false;
	public bool IsLegalGuardian { get; set; } = false;
	public bool IsMedicalPowerOfAttorney { get; set; } = false;

}