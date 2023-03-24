namespace SLS.RM.Domain;

public partial class Prefix
{
	public int PrefixId { get; set; }
	public string PrefixValue { get; set; } = null!;
	public int? SortOrder { get; set; }
	public int RowStatusId { get; set; }
}
