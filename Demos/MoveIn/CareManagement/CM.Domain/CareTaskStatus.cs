namespace SLS.CM.Domain;

public partial class CareTaskStatus
{
	public int CareTaskStatusId { get; set; }
	public string CareTaskStatusName { get; set; } = null!;
	public bool IsDefault { get; set; }
	public int RowStatusId { get; set; }
}