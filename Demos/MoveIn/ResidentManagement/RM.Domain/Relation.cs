namespace SLS.RM.Domain;

public partial class Relation
{
	public int RelationId { get; set; }
	public string RelationName { get; set; } = null!;
	public int SortOrder { get; set; }
	public int RowStatusId { get; set; }
}
