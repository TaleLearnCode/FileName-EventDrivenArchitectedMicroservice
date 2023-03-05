namespace SLS.PM.Domain;

/// <summary>
/// Represents a language with culture differences that is spoken/written.
/// </summary>
public partial class LanguageCulture
{
	public LanguageCulture()
	{
		Communities = new HashSet<Community>();
		ContentCopies = new HashSet<ContentCopy>();
	}

	/// <summary>
	/// Identifier of the language culture record.
	/// </summary>
	public string LanguageCultureCode { get; set; } = null!;
	/// <summary>
	/// Code for the associated language.
	/// </summary>
	public string LanguageCode { get; set; } = null!;
	/// <summary>
	/// The English name of the language culture.
	/// </summary>
	public string EnglishName { get; set; } = null!;
	/// <summary>
	/// The native name of the language culture.
	/// </summary>
	public string NativeName { get; set; } = null!;
	/// <summary>
	/// Identifier of the status for the record (i.e. enabled, disabled, deleted, etc.).
	/// </summary>
	public int RowStatusId { get; set; }

	public virtual ICollection<Community> Communities { get; set; }
	public virtual ICollection<ContentCopy> ContentCopies { get; set; }
}