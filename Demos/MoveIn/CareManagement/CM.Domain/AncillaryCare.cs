namespace SLS.CM.Domain;

public partial class AncillaryCare
{
	public AncillaryCare()
	{
		ResidentAncillaryCares = new HashSet<ResidentAncillaryCare>();
	}

	public int AncillaryCareId { get; set; }
	public int AncillaryCareCategoryId { get; set; }
	public string AncillaryCareName { get; set; } = null!;
	public string? ForegroundColor { get; set; }
	public string? BackgroundColor { get; set; }
	public int? SortOrder { get; set; }

	public virtual AncillaryCareCategory AncillaryCareCategory { get; set; } = null!;
	public virtual ICollection<ResidentAncillaryCare> ResidentAncillaryCares { get; set; }
}
