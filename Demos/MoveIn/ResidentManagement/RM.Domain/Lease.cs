namespace SLS.RM.Domain;

public partial class Lease
{
	public Lease()
	{
		ResidentCommunities = new HashSet<ResidentCommunity>();
	}

	public int LeaseId { get; set; }
	public string ExternalId { get; set; } = null!;
	public int ResidentId { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }

	public virtual Resident Resident { get; set; } = null!;
	public virtual ICollection<ResidentCommunity> ResidentCommunities { get; set; }
}
