namespace SLS.LM.Data;

internal static partial class CreateModel
{

  internal static void ResponsibleParty(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<ResponsibleParty>(entity =>
    {
      entity.ToTable("ResponsibleParty", "LM");

      entity.Property(e => e.ResponsiblePartyId).ValueGeneratedNever();

      entity.Property(e => e.EmailAddress).HasMaxLength(200);

      entity.Property(e => e.ExternalId).HasMaxLength(100);

      entity.Property(e => e.FirstName).HasMaxLength(100);

      entity.Property(e => e.LastName).HasMaxLength(100);

      entity.Property(e => e.MiddleName).HasMaxLength(100);
    });
  }

}