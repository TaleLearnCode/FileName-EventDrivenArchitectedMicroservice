﻿namespace SLS.PM.Domain;

public partial class AncillaryCareCategory
{
	public AncillaryCareCategory()
	{
		AncillaryCares = new HashSet<AncillaryCare>();
	}

	public int AncillaryCareCategoryId { get; set; }
	public string? ExternalId { get; set; }
	public string AncillaryCareCategoryName { get; set; } = null!;
	public string? AncillaryCareCategoryCode { get; set; }
	public string? ForegroundColor { get; set; }
	public string? BackgroundColor { get; set; }
	public bool AssignToNewCommunities { get; set; }
	public int? SortOrder { get; set; }
	public int RowStatusId { get; set; }

	public virtual ICollection<AncillaryCare> AncillaryCares { get; set; }
}