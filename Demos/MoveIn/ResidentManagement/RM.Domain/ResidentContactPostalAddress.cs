namespace SLS.RM.Domain;

public partial class ResidentContactPostalAddress
{
	public int ResidentContactPostalAddressId { get; set; }
	public int ResidentContactId { get; set; }
	public string? ExternalId { get; set; }
	public string? StreetAddress1 { get; set; }
	public string? StreetAddress2 { get; set; }
	public string City { get; set; } = null!;
	public string? CountryDivisionCode { get; set; }
	public string CountryCode { get; set; } = null!;
	public string? PostalCode { get; set; }
	public int? PostalAddressTypeId { get; set; }

	public virtual CountryDivision? Country { get; set; }
	public virtual Country CountryCodeNavigation { get; set; } = null!;
	public virtual ResidentPostalAddressType? PostalAddressType { get; set; }
	public virtual ResidentContact ResidentContact { get; set; } = null!;
}
