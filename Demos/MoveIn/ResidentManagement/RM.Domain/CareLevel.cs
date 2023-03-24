namespace SLS.RM.Domain;

public partial class CareLevel
{
	public CareLevel()
	{
		ResidentCareLevels = new HashSet<ResidentCareLevel>();
	}

	public int CareLevelId { get; set; }
	public int CareTypeId { get; set; }
	public string CareLevelName { get; set; } = null!;
	public int? SortOrder { get; set; }

	public virtual CareType CareType { get; set; } = null!;
	public virtual ICollection<ResidentCareLevel> ResidentCareLevels { get; set; }
}
