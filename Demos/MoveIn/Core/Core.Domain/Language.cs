namespace SLS.Core.Domain;

/// <summary>
/// Represents a spoken/written language.
/// </summary>
public partial class Language
{

	/// <summary>
	/// Identifier of the language.
	/// </summary>
	public string LanguageCode { get; set; } = null!;

	/// <summary>
	/// Name of the language.
	/// </summary>
	public string LanguageName { get; set; } = null!;

	/// <summary>
	/// Native name of the language.
	/// </summary>
	public string NativeName { get; set; } = null!;

	/// <summary>
	/// Identifier of the status for the record (i.e. enabled, disabled, deleted, etc.).
	/// </summary>
	public int RowStatusId { get; set; }

}