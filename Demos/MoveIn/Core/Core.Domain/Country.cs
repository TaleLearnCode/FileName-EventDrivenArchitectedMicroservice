﻿namespace SLS.Core.Domain;

/// <summary>
/// Lookup table representing the countries as defined by the ISO 3166-1 standard.
/// </summary>
public partial class Country
{
	public Country()
	{
		CountryDivisions = new HashSet<CountryDivision>();
	}

	/// <summary>
	/// Identifier of the country as defined by ISO 3166-1.
	/// </summary>
	public string CountryCode { get; set; } = null!;

	/// <summary>
	/// Name of the country using the ISO 3166-1 Country Name.
	/// </summary>
	public string CountryName { get; set; } = null!;

	/// <summary>
	/// Identifier of the world region where the country is located.
	/// </summary>
	public string WorldRegionCode { get; set; } = null!;

	/// <summary>
	/// Identifier of the world subregion where the country is located.
	/// </summary>
	public string? WorldSubregionCode { get; set; }

	/// <summary>
	/// Flag indicating whether the country has divisions (states, provinces, etc.).
	/// </summary>
	public bool HasDivisions { get; set; }

	/// <summary>
	/// The primary name of the country&apos;s divisions.
	/// </summary>
	public string? DivisionName { get; set; }

	/// <summary>
	/// Identifier of the status for the record (i.e. enabled, disabled, deleted, etc.).
	/// </summary>
	public int RowStatusId { get; set; }

	public virtual WorldRegion WorldRegion { get; set; } = null!;

	public virtual WorldRegion? WorldSubregion { get; set; }

	public virtual ICollection<CountryDivision> CountryDivisions { get; set; }

}