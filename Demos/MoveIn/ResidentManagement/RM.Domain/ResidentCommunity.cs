namespace SLS.RM.Domain;

public partial class ResidentCommunity
{
	public ResidentCommunity()
	{
		ResidentAncillaryCares = new HashSet<ResidentAncillaryCare>();
		ResidentCareLevels = new HashSet<ResidentCareLevel>();
	}

	public int ResidentCommunityId { get; set; }
	public int ResidentId { get; set; }
	public int CommunityId { get; set; }
	public int LeaseId { get; set; }

	public virtual Community Community { get; set; } = null!;
	public virtual Lease Lease { get; set; } = null!;
	public virtual Resident Resident { get; set; } = null!;
	public virtual ICollection<ResidentAncillaryCare> ResidentAncillaryCares { get; set; }
	public virtual ICollection<ResidentCareLevel> ResidentCareLevels { get; set; }
}
