namespace SLS.RM.Domain;

public partial class ResidentContactPhoneNumber
{
	public int ResidentContactPhoneNumberId { get; set; }
	public int ResidentContactId { get; set; }
	public int PhoneNumberTypeId { get; set; }
	public string? ExternalId { get; set; }
	public string? CountryCode { get; set; }
	public string PhoneNumber { get; set; } = null!;
	public bool IsDefault { get; set; }

	public virtual ResidentPhoneNumberType PhoneNumberType { get; set; } = null!;
	public virtual ResidentContact ResidentContact { get; set; } = null!;
}
