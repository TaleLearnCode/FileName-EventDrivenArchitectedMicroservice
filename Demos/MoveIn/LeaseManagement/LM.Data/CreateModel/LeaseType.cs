namespace SLS.LM.Data;

internal static partial class CreateModel
{

  internal static void LeaseType(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<LeaseType>(entity =>
    {
      entity.ToTable("LeaseType", "LM");

      entity.HasIndex(e => e.ExternalId, "unqLeaseType_ExternalId")
                .IsUnique()
                .HasFilter("([ExternalId] IS NOT NULL)");

      entity.Property(e => e.ExternalId).HasMaxLength(100);

      entity.Property(e => e.LeaseTypeName).HasMaxLength(100);

      entity.HasOne(d => d.LeaseTermType)
                .WithMany(p => p.LeaseTypes)
                .HasForeignKey(d => d.LeaseTermTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkLeaseType_LeaseTermType");
    });
  }

}