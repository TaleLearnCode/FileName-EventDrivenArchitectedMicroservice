namespace SLS.CM.Domain;

public partial class ResidentCommunity
{
	public ResidentCommunity()
	{
		ResidentAncillaryCares = new HashSet<ResidentAncillaryCare>();
		ResidentRooms = new HashSet<ResidentRoom>();
	}

	public int ResidentCommunityId { get; set; }
	public int ResidentId { get; set; }
	public int CommunityId { get; set; }

	public virtual Community Community { get; set; } = null!;
	public virtual Resident Resident { get; set; } = null!;
	public virtual ICollection<ResidentAncillaryCare> ResidentAncillaryCares { get; set; }
	public virtual ICollection<ResidentRoom> ResidentRooms { get; set; }
}