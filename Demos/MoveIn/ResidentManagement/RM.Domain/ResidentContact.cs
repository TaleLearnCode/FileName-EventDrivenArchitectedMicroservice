namespace SLS.RM.Domain;

public partial class ResidentContact
{
	public ResidentContact()
	{
		ResidentContactPhoneNumbers = new HashSet<ResidentContactPhoneNumber>();
		ResidentContactPostalAddresses = new HashSet<ResidentContactPostalAddress>();
	}

	public int ResidentContactId { get; set; }
	public string? ExternalId { get; set; }
	public int ResidentId { get; set; }
	public int ResidentContactTypeId { get; set; }
	public int RelationId { get; set; }
	public int? SuffixId { get; set; }
	public string? FirstName { get; set; }
	public string? MiddleName { get; set; }
	public string LastName { get; set; } = null!;
	public string? EmailAddress { get; set; }
	public bool HasPowerOfAttorney { get; set; }
	public bool HasDurablePowerOfAttorney { get; set; }
	public bool IsLegalGuardian { get; set; }
	public bool IsMedicalPowerOfAttorney { get; set; }

	public virtual Resident Resident { get; set; } = null!;
	public virtual ResidentContactType ResidentContactType { get; set; } = null!;
	public virtual ICollection<ResidentContactPhoneNumber> ResidentContactPhoneNumbers { get; set; }
	public virtual ICollection<ResidentContactPostalAddress> ResidentContactPostalAddresses { get; set; }
}
