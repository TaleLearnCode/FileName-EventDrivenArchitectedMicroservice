using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Scaffold.Models;

namespace Scaffold.Data
{
    public partial class MoveInCMContext : DbContext
    {
        public MoveInCMContext()
        {
        }

        public MoveInCMContext(DbContextOptions<MoveInCMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AncillaryCare> AncillaryCares { get; set; } = null!;
        public virtual DbSet<AncillaryCareCategory> AncillaryCareCategories { get; set; } = null!;
        public virtual DbSet<CareTask> CareTasks { get; set; } = null!;
        public virtual DbSet<CareTaskStatus> CareTaskStatuses { get; set; } = null!;
        public virtual DbSet<CareTaskType> CareTaskTypes { get; set; } = null!;
        public virtual DbSet<CareType> CareTypes { get; set; } = null!;
        public virtual DbSet<Community> Communities { get; set; } = null!;
        public virtual DbSet<CommunityStatus> CommunityStatuses { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; } = null!;
        public virtual DbSet<Resident> Residents { get; set; } = null!;
        public virtual DbSet<ResidentAncillaryCare> ResidentAncillaryCares { get; set; } = null!;
        public virtual DbSet<ResidentCommunity> ResidentCommunities { get; set; } = null!;
        public virtual DbSet<ResidentRoom> ResidentRooms { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomCareType> RoomCareTypes { get; set; } = null!;
        public virtual DbSet<RowStatus> RowStatuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MoveIn-CM");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AncillaryCare>(entity =>
            {
                entity.ToTable("AncillaryCare", "PM");

                entity.Property(e => e.AncillaryCareName).HasMaxLength(100);

                entity.Property(e => e.BackgroundColor)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ForegroundColor)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.AncillaryCareCategory)
                    .WithMany(p => p.AncillaryCares)
                    .HasForeignKey(d => d.AncillaryCareCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkAncillaryCare_AncillaryCareCategory");
            });

            modelBuilder.Entity<AncillaryCareCategory>(entity =>
            {
                entity.ToTable("AncillaryCareCategory", "PM");

                entity.Property(e => e.AncillaryCareCategoryCode).HasMaxLength(20);

                entity.Property(e => e.AncillaryCareCategoryName).HasMaxLength(100);

                entity.Property(e => e.BackgroundColor)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ForegroundColor)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CareTask>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CareTask", "CM");

                entity.Property(e => e.CareTaskId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<CareTaskStatus>(entity =>
            {
                entity.ToTable("CareTaskStatus", "CM");

                entity.Property(e => e.CareTaskStatusName).HasMaxLength(100);

                entity.Property(e => e.RowStatusId).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CareTaskType>(entity =>
            {
                entity.ToTable("CareTaskType", "CM");

                entity.Property(e => e.CareTaskTypeName).HasMaxLength(100);

                entity.Property(e => e.RowStatusId).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CareType>(entity =>
            {
                entity.ToTable("CareType", "PM");

                entity.HasComment("Represents a type of care provided by a community.");

                entity.HasIndex(e => e.ExternalId, "unqCareType_ExternalId")
                    .IsUnique()
                    .HasFilter("([ExternalId] IS NOT NULL)");

                entity.Property(e => e.CareTypeId).HasComment("Identifier for the care type record.");

                entity.Property(e => e.BackgroundColor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("The background color to use when displaying the care type within the Glennis suite of products.");

                entity.Property(e => e.CareTypeCode)
                    .HasMaxLength(20)
                    .HasComment("The code assigned to the care type.");

                entity.Property(e => e.CareTypeName)
                    .HasMaxLength(100)
                    .HasComment("The name of the care type.");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(100)
                    .HasComment("The tenant's identifier for the care type.");

                entity.Property(e => e.ForegroundColor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("The foreground color to use when displaying the care type within the Glennis suite of products.");

                entity.Property(e => e.PriceVarianceThreshold).HasComment("The threshold of price variance before hiding pricing within the PPM listing services.");

                entity.Property(e => e.RowStatusId)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Identifier of the care type record status (i.e. enabled, disabled, etc).");
            });

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

                entity.HasOne(d => d.CommunityStatus)
                    .WithMany(p => p.Communities)
                    .HasForeignKey(d => d.CommunityStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCommunity_CommunityStatus");
            });

            modelBuilder.Entity<CommunityStatus>(entity =>
            {
                entity.ToTable("CommunityStatus", "PM");

                entity.HasComment("Represents the different statuses for a community.");

                entity.Property(e => e.CommunityStatusId)
                    .ValueGeneratedNever()
                    .HasComment("The identifier of the community status record.");

                entity.Property(e => e.CommunityStatusName)
                    .HasMaxLength(100)
                    .HasComment("The name of the community status.");

                entity.Property(e => e.RowStatusId)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Identifier of the Community Status record status (i.e. enabled, disabled, etc).");

                entity.Property(e => e.SortOrder).HasComment("The sorting order of the Community Status among the other community statuses.");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", "CM");

                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.RowStatusId).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<EmployeeRole>(entity =>
            {
                entity.ToTable("EmployeeRole", "CM");

                entity.Property(e => e.EmployeeRoleCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeRoleName).HasMaxLength(100);

                entity.Property(e => e.RowStatusId).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Resident>(entity =>
            {
                entity.ToTable("Resident", "RM");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.MiddleName).HasMaxLength(100);
            });

            modelBuilder.Entity<ResidentAncillaryCare>(entity =>
            {
                entity.ToTable("ResidentAncillaryCare", "RM");

                entity.ToTable(tb => tb.IsTemporal(ttb =>
    {
        ttb.UseHistoryTable("ResidentAncillaryCareHistory", "RM");
        ttb
            .HasPeriodStart("ValidFrom")
            .HasColumnName("ValidFrom");
        ttb
            .HasPeriodEnd("ValidTo")
            .HasColumnName("ValidTo");
    }
));

                entity.HasOne(d => d.AncillaryCare)
                    .WithMany(p => p.ResidentAncillaryCares)
                    .HasForeignKey(d => d.AncillaryCareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkResidentAncillaryCare_AncillaryCare");

                entity.HasOne(d => d.ResidentCommunity)
                    .WithMany(p => p.ResidentAncillaryCares)
                    .HasForeignKey(d => d.ResidentCommunityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkResidentAncillaryCare_ResidentCommunity");
            });

            modelBuilder.Entity<ResidentCommunity>(entity =>
            {
                entity.ToTable("ResidentCommunity", "RM");

                entity.ToTable(tb => tb.IsTemporal(ttb =>
    {
        ttb.UseHistoryTable("ResidentCommunityHistory", "RM");
        ttb
            .HasPeriodStart("ValidFrom")
            .HasColumnName("ValidFrom");
        ttb
            .HasPeriodEnd("ValidTo")
            .HasColumnName("ValidTo");
    }
));

                entity.Property(e => e.ResidentCommunityId).ValueGeneratedNever();

                entity.HasOne(d => d.Community)
                    .WithMany(p => p.ResidentCommunities)
                    .HasForeignKey(d => d.CommunityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkResidentCommunity_Community");

                entity.HasOne(d => d.Resident)
                    .WithMany(p => p.ResidentCommunities)
                    .HasForeignKey(d => d.ResidentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkResidentCommunity_Resident");
            });

            modelBuilder.Entity<ResidentRoom>(entity =>
            {
                entity.ToTable("ResidentRoom", "RM");

                entity.ToTable(tb => tb.IsTemporal(ttb =>
    {
        ttb.UseHistoryTable("ResidentRoomHistory", "PM");
        ttb
            .HasPeriodStart("ValidFrom")
            .HasColumnName("ValidFrom");
        ttb
            .HasPeriodEnd("ValidTo")
            .HasColumnName("ValidTo");
    }
));

                entity.HasOne(d => d.CareType)
                    .WithMany(p => p.ResidentRooms)
                    .HasForeignKey(d => d.CareTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkResidentRoom_CareType");

                entity.HasOne(d => d.ResidentCommunity)
                    .WithMany(p => p.ResidentRooms)
                    .HasForeignKey(d => d.ResidentCommunityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkResidentRoom_ResidentCommunity");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.ResidentRooms)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkResidentRoom_Room");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room", "PM");

                entity.HasComment("Represents a room within a community.");

                entity.HasIndex(e => e.CommunityId, "idxRoom_CommunityId");

                entity.Property(e => e.RoomId)
                    .ValueGeneratedNever()
                    .HasComment("Identifier of the room record.");

                entity.Property(e => e.CommunityId).HasComment("Identifier of the associated community record.");

                entity.Property(e => e.RoomNumber)
                    .HasMaxLength(100)
                    .HasComment("The number of the room.");

                entity.HasOne(d => d.Community)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.CommunityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkRoom_Community");
            });

            modelBuilder.Entity<RoomCareType>(entity =>
            {
                entity.ToTable("RoomCareType", "PM");

                entity.HasComment("Defines the care types assigned to a particular room.");

                entity.Property(e => e.RoomCareTypeId).HasComment("Identifier for the room/care type association record.");

                entity.Property(e => e.CareTypeId).HasComment("Identifier for the associated care type record.");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(100)
                    .HasComment("The operator's identifier for the room/care type association.");

                entity.Property(e => e.RoomId).HasComment("Identifier for the associated room record.");

                entity.HasOne(d => d.CareType)
                    .WithMany(p => p.RoomCareTypes)
                    .HasForeignKey(d => d.CareTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkRoomCareType_CareType");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomCareTypes)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkRoomCareType_Room");
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
