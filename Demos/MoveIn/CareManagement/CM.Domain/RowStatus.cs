namespace SLS.CM.Domain;

/// <summary>
/// Represents the status of a record (i.e. enabled, disabled, etc.).
/// </summary>
public partial class RowStatus
{
	/// <summary>
	/// Identifier for the row status record.
	/// </summary>
	public int RowStatusId { get; set; }
	/// <summary>
	/// The name of the row status.
	/// </summary>
	public string RowStatusName { get; set; } = null!;
	/// <summary>
	/// Flag indicating whether the records of the row status are displayed.
	/// </summary>
	public bool IsDisplayed { get; set; }
	/// <summary>
	/// Flag indicating whether the row status is active.
	/// </summary>
	public bool IsActive { get; set; }
}