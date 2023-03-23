using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Scaffold.Models;

namespace Scaffold.Data
{
    public partial class MoveInLMContext : DbContext
    {
        public MoveInLMContext()
        {
        }

        public MoveInLMContext(DbContextOptions<MoveInLMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Community> Communities { get; set; } = null!;
        public virtual DbSet<Lease> Leases { get; set; } = null!;
        public virtual DbSet<LeaseTermType> LeaseTermTypes { get; set; } = null!;
        public virtual DbSet<LeaseType> LeaseTypes { get; set; } = null!;
        public virtual DbSet<Lessee> Lessees { get; set; } = null!;
        public virtual DbSet<Prefix> Prefixes { get; set; } = null!;
        public virtual DbSet<Resident> Residents { get; set; } = null!;
        public virtual DbSet<ResponsibleParty> ResponsibleParties { get; set; } = null!;
        public virtual DbSet<RowStatus> RowStatuses { get; set; } = null!;
        public virtual DbSet<Suffix> Suffixes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=MoveIn-LM;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Community>(entity =>
            {
                entity.ToTable("Community", "PM");

                entity.HasComment("Represents a community run by the tenant.");

                entity.HasIndex(e => e.CommunityNumber, "idxCommunity_CommunityNumber");

                entity.HasIndex(e => e.CommunityNumber, "unqCommunity_CommunityNumber")
                    .IsUnique();

                entity.Property(e => e.CommunityId)
                    .ValueGeneratedNever()
                    .HasComment("The identifier of the community record.");

                entity.Property(e => e.CommunityName)
                    .HasMaxLength(200)
                    .HasComment("The name of the community.");

                entity.Property(e => e.CommunityNumber)
                    .HasMaxLength(50)
                    .HasComment("The tenant's number (identifier) for the community.");

                entity.Property(e => e.ProfileImageUrl)
                    .HasMaxLength(500)
                    .HasComment("URL of the digital asset that serves as the profile image for the community.");

                entity.Property(e => e.RowStatusId).HasComment("Identifier of the community record status (i.e. enabled, disabled, etc).");
            });

            modelBuilder.Entity<Lease>(entity =>
            {
                entity.ToTable("Lease", "LM");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ExternalId).HasMaxLength(100);

                entity.Property(e => e.Rate).HasColumnType("smallmoney");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.LeaseType)
                    .WithMany(p => p.Leases)
                    .HasForeignKey(d => d.LeaseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkLease_LeaseType");

                entity.HasOne(d => d.Resident)
                    .WithMany(p => p.Leases)
                    .HasForeignKey(d => d.ResidentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkLease_Resident");
            });

            modelBuilder.Entity<LeaseTermType>(entity =>
            {
                entity.ToTable("LeaseTermType", "LM");

                entity.Property(e => e.LeaseTermTypeId).ValueGeneratedNever();

                entity.Property(e => e.LeaseTermTypeName).HasMaxLength(100);
            });

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

            modelBuilder.Entity<Lessee>(entity =>
            {
                entity.ToTable("Lessee", "LM");

                entity.Property(e => e.LesseeId).ValueGeneratedNever();

                entity.Property(e => e.EmailAddress).HasMaxLength(200);

                entity.Property(e => e.ExternalId).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.MiddleName).HasMaxLength(100);
            });

            modelBuilder.Entity<Prefix>(entity =>
            {
                entity.ToTable("Prefix", "Core");

                entity.Property(e => e.PrefixId).ValueGeneratedNever();

                entity.Property(e => e.PrefixValue).HasMaxLength(100);
            });

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

            modelBuilder.Entity<RowStatus>(entity =>
            {
                entity.ToTable("RowStatus", "Core");

                entity.HasComment("Represents the status of a record (i.e. enabled, disabled, etc.).");

                entity.Property(e => e.RowStatusId)
                    .ValueGeneratedNever()
                    .HasComment("Identifier for the row status record.");

                entity.Property(e => e.IsActive).HasComment("Flag indicating whether the row status is active.");

                entity.Property(e => e.IsDisplayed).HasComment("Flag indicating whether the records of the row status are displayed.");

                entity.Property(e => e.RowStatusName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("The name of the row status.");
            });

            modelBuilder.Entity<Suffix>(entity =>
            {
                entity.ToTable("Suffix", "Core");

                entity.Property(e => e.SuffixId).ValueGeneratedNever();

                entity.Property(e => e.SuffixValue).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
