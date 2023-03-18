namespace SLS.CM.Domain;

public partial class ResidentAncillaryCare
{
	public int ResidentAncillaryCareId { get; set; }
	public int ResidentCommunityId { get; set; }
	public int AncillaryCareId { get; set; }

	public virtual AncillaryCare AncillaryCare { get; set; } = null!;
	public virtual ResidentCommunity ResidentCommunity { get; set; } = null!;
}