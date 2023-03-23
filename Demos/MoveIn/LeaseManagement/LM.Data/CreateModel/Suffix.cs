namespace SLS.LM.Data;

internal static partial class CreateModel
{

  internal static void Suffix(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Suffix>(entity =>
    {
      entity.ToTable("Suffix", "Core");

      entity.Property(e => e.SuffixId).ValueGeneratedNever();

      entity.Property(e => e.SuffixValue).HasMaxLength(100);
    });
  }

}