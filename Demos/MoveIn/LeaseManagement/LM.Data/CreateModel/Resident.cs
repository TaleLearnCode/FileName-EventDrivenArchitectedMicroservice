namespace SLS.LM.Data;

internal static partial class CreateModel
{

  internal static void Resident(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Resident>(entity =>
    {
      entity.ToTable("Resident", "RM");

      entity.Property(e => e.FirstName).HasMaxLength(100);

      entity.Property(e => e.LastName).HasMaxLength(100);

      entity.Property(e => e.MiddleName).HasMaxLength(100);

      entity.HasOne(d => d.Lessee)
          .WithMany(p => p.Residents)
          .HasForeignKey(d => d.LesseeId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("fkResident_Lessee");

      entity.HasOne(d => d.ResponsibleParty)
          .WithMany(p => p.Residents)
          .HasForeignKey(d => d.ResponsiblePartyId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("fkResident_ResponsibleParty");
    });
  }

}