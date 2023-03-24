namespace SLS.RM.Domain;

public partial class ResidentCareLevel
{
	public int ResidentCareLevelId { get; set; }
	public int ResidentCommunityId { get; set; }
	public int CareLevelId { get; set; }
	public decimal Rate { get; set; }
	public DateTime EffectiveDate { get; set; }

	public virtual CareLevel CareLevel { get; set; } = null!;
	public virtual ResidentCommunity ResidentCommunity { get; set; } = null!;
}
