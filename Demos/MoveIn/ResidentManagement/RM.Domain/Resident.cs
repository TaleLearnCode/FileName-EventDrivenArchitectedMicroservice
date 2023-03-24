namespace SLS.RM.Domain;

public partial class Resident
{
	public Resident()
	{
		Leases = new HashSet<Lease>();
		ResidentCommunities = new HashSet<ResidentCommunity>();
		ResidentContacts = new HashSet<ResidentContact>();
	}

	public int ResidentId { get; set; }
	public string? ExternalId { get; set; }
	public string? FirstName { get; set; }
	public string? MiddleName { get; set; }
	public string LastName { get; set; } = null!;
	public DateTime DateOfBirth { get; set; }

	public virtual ICollection<Lease> Leases { get; set; }
	public virtual ICollection<ResidentCommunity> ResidentCommunities { get; set; }
	public virtual ICollection<ResidentContact> ResidentContacts { get; set; }
}
