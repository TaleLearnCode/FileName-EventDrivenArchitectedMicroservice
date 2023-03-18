namespace SLS.CM.Domain;

public partial class Resident
{
	public Resident()
	{
		ResidentCommunities = new HashSet<ResidentCommunity>();
	}

	public int ResidentId { get; set; }
	public string? FirstName { get; set; }
	public string? MiddleName { get; set; }
	public string LastName { get; set; } = null!;
	public DateTime DateOfBirth { get; set; }

	public virtual ICollection<ResidentCommunity> ResidentCommunities { get; set; }
}
