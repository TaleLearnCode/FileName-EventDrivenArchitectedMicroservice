namespace SLS.Core.Data;

internal static partial class CreateModel
{

	internal static void LanguageCulture(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<LanguageCulture>(entity =>
		{
			entity.HasKey(e => e.LanguageCultureCode)
					.HasName("pkcLanguageCulture");

			entity.ToTable("LanguageCulture", "Core");

			entity.HasComment("Represents a language with culture differences that is spoken/written.");

			entity.Property(e => e.LanguageCultureCode)
					.HasMaxLength(15)
					.IsUnicode(false)
					.HasComment("Identifier of the language culture record.");

			entity.Property(e => e.EnglishName)
					.HasMaxLength(100)
					.HasComment("The English name of the language culture.");

			entity.Property(e => e.LanguageCode)
					.HasMaxLength(3)
					.IsUnicode(false)
					.IsFixedLength()
					.HasComment("Code for the associated language.");

			entity.Property(e => e.NativeName)
					.HasMaxLength(100)
					.HasComment("The native name of the language culture.");

			entity.Property(e => e.RowStatusId).HasComment("Identifier of the status for the record (i.e. enabled, disabled, deleted, etc.).");
		});
	}

}