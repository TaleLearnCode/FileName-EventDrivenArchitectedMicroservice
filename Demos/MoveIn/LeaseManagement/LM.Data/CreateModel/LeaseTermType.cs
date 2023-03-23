namespace SLS.LM.Data;

internal static partial class CreateModel
{

  internal static void LeaseTermType(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<LeaseTermType>(entity =>
    {
      entity.ToTable("LeaseTermType", "LM");

      entity.Property(e => e.LeaseTermTypeId).ValueGeneratedNever();

      entity.Property(e => e.LeaseTermTypeName).HasMaxLength(100);
    });
  }

}