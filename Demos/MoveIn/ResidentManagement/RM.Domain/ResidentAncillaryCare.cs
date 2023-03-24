namespace SLS.RM.Domain;

public partial class ResidentAncillaryCare
{
	public int ResidentAncillaryCareId { get; set; }
	public int ResidentCommunityId { get; set; }
	public int AncillaryCareId { get; set; }
	public decimal Rate { get; set; }
	public DateTime EffectiveDate { get; set; }

	public virtual AncillaryCare AncillaryCare { get; set; } = null!;
	public virtual ResidentCommunity ResidentCommunity { get; set; } = null!;
}
