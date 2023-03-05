namespace SLS.Core.Domain;

/// <summary>
/// Lookup table representing the world regions as defined by the ISO 3166-2 standard.
/// </summary>
public partial class CountryDivision
{

	/// <summary>
	/// Identifier of the country division using the ISO 3166-2 Alpha-2 code.
	/// </summary>
	public string CountryDivisionCode { get; set; } = null!;

	/// <summary>
	/// Identifier of the country the country division is associated with.
	/// </summary>
	public string CountryCode { get; set; } = null!;

	/// <summary>
	/// Name of the country using the ISO 3166-2 Subdivision Name.
	/// </summary>
	public string CountryDivisionName { get; set; } = null!;

	/// <summary>
	/// The category name of the country division.
	/// </summary>
	public string CategoryName { get; set; } = null!;

	/// <summary>
	/// Identifier of the status for the record (i.e. enabled, disabled, deleted, etc.).
	/// </summary>
	public int RowStatusId { get; set; }


	public virtual Country Country { get; set; } = null!;

}