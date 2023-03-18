using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Scaffold.Models;

namespace Scaffold.Data
{
    public partial class MoveInPMContext : DbContext
    {
        public MoveInPMContext()
        {
        }

        public MoveInPMContext(DbContextOptions<MoveInPMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AncillaryCare> AncillaryCares { get; set; } = null!;
        public virtual DbSet<AncillaryCareCategory> AncillaryCareCategories { get; set; } = null!;
        public virtual DbSet<CareLevel> CareLevels { get; set; } = null!;
        public virtual DbSet<CareType> CareTypes { get; set; } = null!;
        public virtual DbSet<Community> Communities { get; set; } = null!;
        public virtual DbSet<CommunityAncillaryCare> CommunityAncillaryCares { get; set; } = null!;
        public virtual DbSet<CommunityCareLevel> CommunityCareLevels { get; set; } = null!;
        public virtual DbSet<CommunityCareType> CommunityCareTypes { get; set; } = null!;
        public virtual DbSet<CommunityPhoneNumber> CommunityPhoneNumbers { get; set; } = null!;
        public virtual DbSet<CommunityPostalAddress> CommunityPostalAddresses { get; set; } = null!;
        public virtual DbSet<CommunityRoomType> CommunityRoomTypes { get; set; } = null!;
        public virtual DbSet<CommunityStatus> CommunityStatuses { get; set; } = null!;
        public virtual DbSet<CommunityStructure> CommunityStructures { get; set; } = null!;
        public virtual DbSet<CommunityStructureType> CommunityStructureTypes { get; set; } = null!;
        public virtual DbSet<Content> Contents { get; set; } = null!;
        public virtual DbSet<ContentCopy> ContentCopies { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<CountryDivision> CountryDivisions { get; set; } = null!;
        public virtual DbSet<DigitalAsset> DigitalAssets { get; set; } = null!;
        public virtual DbSet<DigitalAssetType> DigitalAssetTypes { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<LanguageCulture> LanguageCultures { get; set; } = null!;
        public virtual DbSet<PayorType> PayorTypes { get; set; } = null!;
        public virtual DbSet<PhoneNumberType> PhoneNumberTypes { get; set; } = null!;
        public virtual DbSet<PostalAddressType> PostalAddressTypes { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomAvailability> RoomAvailabilities { get; set; } = null!;
        public virtual DbSet<RoomCareType> RoomCareTypes { get; set; } = null!;
        public virtual DbSet<RoomRate> RoomRates { get; set; } = null!;
        public virtual DbSet<RoomStyle> RoomStyles { get; set; } = null!;
        public virtual DbSet<RoomType> RoomTypes { get; set; } = null!;
        public virtual DbSet<RoomTypeCategory> RoomTypeCategories { get; set; } = null!;
        public virtual DbSet<RowStatus> RowStatuses { get; set; } = null!;
        public virtual DbSet<WorldRegion> WorldRegions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Beast;Initial Catalog=MoveIn-PM;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AncillaryCare>(entity =>
            {
                entity.ToTable("AncillaryCare", "PM");

                entity.HasIndex(e => e.ExternalId, "unqAncillaryCare_ExternalId")
                    .IsUnique()
                    .HasFilter("([ExternalId] IS NOT NULL)");

                entity.Property(e => e.AncillaryCareName).HasMaxLength(100);

                entity.Property(e => e.BackgroundColor)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExternalId).HasMaxLength(100);

                entity.Property(e => e.ForegroundColor)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RowStatusId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.AncillaryCareCategory)
                    .WithMany(p => p.AncillaryCares)
                    .HasForeignKey(d => d.AncillaryCareCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkAncillaryCare_AncillaryCareCategory");
            });

            modelBuilder.Entity<AncillaryCareCategory>(entity =>
            {
                entity.ToTable("AncillaryCareCategory", "PM");

                entity.HasIndex(e => e.ExternalId, "unqAncillaryCareCategory_ExternalId")
                    .IsUnique()
                    .HasFilter("([ExternalId] IS NOT NULL)");

                entity.Property(e => e.AncillaryCareCategoryCode).HasMaxLength(20);

                entity.Property(e => e.AncillaryCareCategoryName).HasMaxLength(100);

                entity.Property(e => e.BackgroundColor)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExternalId).HasMaxLength(100);

                entity.Property(e => e.ForegroundColor)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RowStatusId).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CareLevel>(entity =>
            {
                entity.ToTable("CareLevel", "PM");

                entity.HasIndex(e => e.ExternalId, "unqCareLevel_ExternalId")
                    .IsUnique()
                    .HasFilter("([ExternalId] IS NOT NULL)");

                entity.Property(e => e.CareLevelId).ValueGeneratedNever();

                entity.Property(e => e.AssignToNewCommunities)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CareLevelName).HasMaxLength(100);

                entity.Property(e => e.ExternalId).HasMaxLength(100);

                entity.HasOne(d => d.CareType)
                    .WithMany(p => p.CareLevels)
                    .HasForeignKey(d => d.CareTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCareLevel_CareType");
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

                entity.Property(e => e.CommunityId).HasComment("The identifier of the community record.");

                entity.Property(e => e.CommunityName)
                    .HasMaxLength(200)
                    .HasComment("The name of the community.");

                entity.Property(e => e.CommunityNumber)
                    .HasMaxLength(50)
                    .HasComment("The tenant's number (identifier) for the community.");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Identifier of the country the community is located in.");

                entity.Property(e => e.ExternalName)
                    .HasMaxLength(200)
                    .HasComment("The name of the community used externally.");

                entity.Property(e => e.IsFeatured).HasComment("Flag indicating whether the community is featured.");

                entity.Property(e => e.LanguageCultureCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('en-US')")
                    .HasComment("The default language culture to be used for the community.");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasComment("The latitude where the community is located.");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasComment("The longitude where the community is located.");

                entity.Property(e => e.ProfileImageId).HasComment("Identifier of the digital asset that serves as the profile image for the community.");

                entity.Property(e => e.RoomMeasurement)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('sq ft')")
                    .HasComment("The measurement type used for room area (i.e. square feet, square meters, etc.)");

                entity.Property(e => e.RowStatusId)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Identifier of the community record status (i.e. enabled, disabled, etc).");

                entity.HasOne(d => d.CommunityStatus)
                    .WithMany(p => p.Communities)
                    .HasForeignKey(d => d.CommunityStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCommunity_CommunityStatus");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Communities)
                    .HasForeignKey(d => d.CountryCode)
                    .HasConstraintName("fkCommunity_Country");

                entity.HasOne(d => d.LanguageCultureCodeNavigation)
                    .WithMany(p => p.Communities)
                    .HasForeignKey(d => d.LanguageCultureCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCommunity_LanguageCultureCode");

                entity.HasOne(d => d.Overview)
                    .WithMany(p => p.Communities)
                    .HasForeignKey(d => d.OverviewId)
                    .HasConstraintName("fkCommunity_Content");

                entity.HasOne(d => d.ProfileImage)
                    .WithMany(p => p.Communities)
                    .HasForeignKey(d => d.ProfileImageId)
                    .HasConstraintName("fkCommunity_DigitalAsset");
            });

            modelBuilder.Entity<CommunityAncillaryCare>(entity =>
            {
                entity.ToTable("CommunityAncillaryCare", "PM");

                entity.ToTable(tb => tb.IsTemporal(ttb =>
    {
        ttb.UseHistoryTable("CommunityAncillaryCareHistory", "PM");
        ttb
            .HasPeriodStart("ValidFrom")
            .HasColumnName("ValidFrom");
        ttb
            .HasPeriodEnd("ValidTo")
            .HasColumnName("ValidTo");
    }
));

                entity.Property(e => e.BaseRate).HasColumnType("smallmoney");

                entity.Property(e => e.DailyRate).HasColumnType("smallmoney");

                entity.Property(e => e.ExternalId).HasMaxLength(100);

                entity.HasOne(d => d.AncillaryCare)
                    .WithMany(p => p.CommunityAncillaryCares)
                    .HasForeignKey(d => d.AncillaryCareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCommunityAncillaryCare_AncillaryCare");

                entity.HasOne(d => d.Community)
                    .WithMany(p => p.CommunityAncillaryCares)
                    .HasForeignKey(d => d.CommunityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCommunityAncillaryCare_Community");
            });

            modelBuilder.Entity<CommunityCareLevel>(entity =>
            {
                entity.ToTable("CommunityCareLevel", "PM");

                entity.ToTable(tb => tb.IsTemporal(ttb =>
    {
        ttb.UseHistoryTable("CommunityCareLevelHistory", "PM");
        ttb
            .HasPeriodStart("ValidFrom")
            .HasColumnName("ValidFrom");
        ttb
            .HasPeriodEnd("ValidTo")
            .HasColumnName("ValidTo");
    }
));

                entity.Property(e => e.BaseRate).HasColumnType("smallmoney");

                entity.Property(e => e.DailyRate).HasColumnType("smallmoney");

                entity.HasOne(d => d.CareLevel)
                    .WithMany(p => p.CommunityCareLevels)
                    .HasForeignKey(d => d.CareLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCommunityCareLevel_CareLevel");

                entity.HasOne(d => d.Community)
                    .WithMany(p => p.CommunityCareLevels)
                    .HasForeignKey(d => d.CommunityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCommunityCareLevel_Community");
            });

            modelBuilder.Entity<CommunityCareType>(entity =>
            {
                entity.ToTable("CommunityCareType", "PM");

                entity.HasComment("Represents the care types provided by a community.");

                entity.Property(e => e.CommunityCareTypeId).HasComment("Identifier for the community/care type association.");

                entity.Property(e => e.CareTypeId).HasComment("Identifier for the associated care type.");

                entity.Property(e => e.CommunityId).HasComment("Identifier for the associated community.");

                entity.HasOne(d => d.CareType)
                    .WithMany(p => p.CommunityCareTypes)
                    .HasForeignKey(d => d.CareTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCommunityCareType_CareType");

                entity.HasOne(d => d.Community)
                    .WithMany(p => p.CommunityCareTypes)
                    .HasForeignKey(d => d.CommunityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCommunityCareType_Community");
            });

            modelBuilder.Entity<CommunityPhoneNumber>(entity =>
            {
                entity.ToTable("CommunityPhoneNumber", "PM");

                entity.HasComment("Represents the linking of a community to an phone number.");

                entity.Property(e => e.CommunityId).HasComment("The identifier of the associated community record.");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ExternalId).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Community)
                    .WithMany(p => p.CommunityPhoneNumbers)
                    .HasForeignKey(d => d.CommunityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCommunityPhoneNumber_Community");

                entity.HasOne(d => d.PhoneNumberType)
                    .WithMany(p => p.CommunityPhoneNumbers)
                    .HasForeignKey(d => d.PhoneNumberTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCommunityPhoneNumber_PhoneNumberType");
            });

            modelBuilder.Entity<CommunityPostalAddress>(entity =>
            {
                entity.ToTable("CommunityPostalAddress", "PM");

                entity.HasComment("Represents the linking of a community to an address.");

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CountryDivisionCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExternalId).HasMaxLength(100);

                entity.Property(e => e.PostalCode).HasMaxLength(20);

                entity.Property(e => e.StreetAddress1).HasMaxLength(100);

                entity.Property(e => e.StreetAddress2).HasMaxLength(100);

                entity.HasOne(d => d.Community)
                    .WithMany(p => p.CommunityPostalAddresses)
                    .HasForeignKey(d => d.CommunityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCommunityPostalAddress_Community");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.CommunityPostalAddresses)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCommunityPostalAddress_Country");

                entity.HasOne(d => d.PostalAddressType)
                    .WithMany(p => p.CommunityPostalAddresses)
                    .HasForeignKey(d => d.PostalAddressTypeId)
                    .HasConstraintName("fkCommunityPostalAddress_PostalAddressType");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CommunityPostalAddresses)
                    .HasForeignKey(d => new { d.CountryCode, d.CountryDivisionCode })
                    .HasConstraintName("fkCommunityPostalAddress_CountryDivision");
            });

            modelBuilder.Entity<CommunityRoomType>(entity =>
            {
                entity.ToTable("CommunityRoomType", "PM");

                entity.HasComment("Represents the relationship between the RoomType and Community tables.");

                entity.Property(e => e.CommunityRoomTypeId).HasComment("Identifier of the community room type record.");

                entity.Property(e => e.CareTypeId).HasComment("Identifier of the associated CareType record.");

                entity.Property(e => e.CommunityId).HasComment("Identifier of the associated Community record.");

                entity.Property(e => e.FloorPlanId).HasComment("Identifier of the digital asset representing the floor plan for the room type within the community.");

                entity.Property(e => e.RoomTypeId).HasComment("Identifier of the associated RoomType record.");

                entity.HasOne(d => d.CareType)
                    .WithMany(p => p.CommunityRoomTypes)
                    .HasForeignKey(d => d.CareTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCommunityRoomType_CareType");

                entity.HasOne(d => d.Community)
                    .WithMany(p => p.CommunityRoomTypes)
                    .HasForeignKey(d => d.CommunityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCommunityRoomType_Community");

                entity.HasOne(d => d.FloorPlan)
                    .WithMany(p => p.CommunityRoomTypes)
                    .HasForeignKey(d => d.FloorPlanId)
                    .HasConstraintName("fkCommunityRoomType_DigitalAsset");
            });

            modelBuilder.Entity<CommunityStatus>(entity =>
            {
                entity.ToTable("CommunityStatus", "PM");

                entity.HasComment("Represents the different statuses for a community.");

                entity.HasIndex(e => e.ExternalId, "unqCommunityStatus_ExternalId")
                    .IsUnique()
                    .HasFilter("([ExternalId] IS NOT NULL)");

                entity.Property(e => e.CommunityStatusId).HasComment("The identifier of the community status record.");

                entity.Property(e => e.CommunityStatusName)
                    .HasMaxLength(100)
                    .HasComment("The name of the community status.");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(100)
                    .HasComment("The tenant's identifier for the community status record.");

                entity.Property(e => e.RowStatusId)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Identifier of the Community Status record status (i.e. enabled, disabled, etc).");

                entity.Property(e => e.SortOrder).HasComment("The sorting order of the Community Status among the other community statuses.");
            });

            modelBuilder.Entity<CommunityStructure>(entity =>
            {
                entity.ToTable("CommunityStructure", "PM");

                entity.HasComment("Represents an element of the structure (floor, building, etc.) within a community.");

                entity.Property(e => e.CommunityStructureId).HasComment("Identifier of the community structure record.");

                entity.Property(e => e.CommunityId).HasComment("Identifier of the community the element is defining the structure of.");

                entity.Property(e => e.CommunityStructureCode)
                    .HasMaxLength(20)
                    .HasComment("The code for the community structure.");

                entity.Property(e => e.CommunityStructureName)
                    .HasMaxLength(100)
                    .HasComment("The name of the community structure.");

                entity.Property(e => e.CommunityStructureTypeId).HasComment("Identifier of the community structure's type.");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(100)
                    .HasComment("The tenant's identifier for the community structure.");

                entity.Property(e => e.ParentId).HasComment("Identifier of the community structure's parent (example the building a floor is in).");

                entity.Property(e => e.RowStatusId)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Identifier of the status of the community attribute type record (i.e. enabled, disabled, etc).");

                entity.Property(e => e.SortOrder).HasComment("The sorting order of the community structure among the other community structures.");

                entity.HasOne(d => d.Community)
                    .WithMany(p => p.CommunityStructures)
                    .HasForeignKey(d => d.CommunityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCommunityStructure_Community");

                entity.HasOne(d => d.CommunityStructureType)
                    .WithMany(p => p.CommunityStructures)
                    .HasForeignKey(d => d.CommunityStructureTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCommunityStructure_CommunityStructureType");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("fkCommunityStructure_CommunityStructure");
            });

            modelBuilder.Entity<CommunityStructureType>(entity =>
            {
                entity.ToTable("CommunityStructureType", "PM");

                entity.HasComment("Represents the type of a community structure (floor, building, etc.).");

                entity.HasIndex(e => e.ExternalId, "unqCommunityStructureType_ExternalId")
                    .IsUnique()
                    .HasFilter("([ExternalId] IS NOT NULL)");

                entity.HasIndex(e => e.ExternalId, "unqCommunityStructure_ExternalId")
                    .IsUnique()
                    .HasFilter("([ExternalId] IS NOT NULL)");

                entity.Property(e => e.CommunityStructureTypeId).HasComment("Identifier of the community structure type record.");

                entity.Property(e => e.CommunityStructureTypeName)
                    .HasMaxLength(100)
                    .HasComment("The name of the community structure type.");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(100)
                    .HasComment("The tenant's identifier for the community structure type.");

                entity.Property(e => e.RowStatusId)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Identifier of the community structure record status (i.e. enabled, disabled, etc).");

                entity.Property(e => e.SortOrder).HasComment("The sorting order of the community structure type among the other community structure types.");
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.ToTable("Content", "DCM");

                entity.HasComment("Represents content for an item managed by the system.");

                entity.Property(e => e.ContentId).HasComment("Identifier of the Content record.");

                entity.Property(e => e.ContentName)
                    .HasMaxLength(100)
                    .HasComment("The name of the Content.");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(100)
                    .HasComment("The Tenant's identifier for the Content record.");
            });

            modelBuilder.Entity<ContentCopy>(entity =>
            {
                entity.HasKey(e => new { e.ContentId, e.LanguageCultureCode })
                    .HasName("pkcContentCopy");

                entity.ToTable("ContentCopy", "DCM");

                entity.HasComment("Represents content for an item managed by the system.");

                entity.Property(e => e.ContentId).HasComment("Identifier of the associated Content record.");

                entity.Property(e => e.LanguageCultureCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasComment("Identifier of the associated LanguageCulture record.");

                entity.Property(e => e.CopyText).HasComment("The text of the content copy.");

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.ContentCopies)
                    .HasForeignKey(d => d.ContentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkContentCopy_Content");

                entity.HasOne(d => d.LanguageCultureCodeNavigation)
                    .WithMany(p => p.ContentCopies)
                    .HasForeignKey(d => d.LanguageCultureCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkContentCopy_LanguageCulture");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryCode)
                    .HasName("pkcCountry");

                entity.ToTable("Country", "Core");

                entity.HasComment("Lookup table representing the countries as defined by the ISO 3166-1 standard.");

                entity.HasIndex(e => e.WorldRegionCode, "idxCountry_WorldRegionCode");

                entity.HasIndex(e => e.WorldSubregionCode, "idxCountry_WorldSubregionCode");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Identifier of the country as defined by ISO 3166-1.");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Name of the country using the ISO 3166-1 Country Name.");

                entity.Property(e => e.DivisionName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("The primary name of the country's divisions.");

                entity.Property(e => e.HasDivisions).HasComment("Flag indicating whether the country has divisions (states, provinces, etc.).");

                entity.Property(e => e.RowStatusId).HasComment("Identifier of the status for the record (i.e. enabled, disabled, deleted, etc.).");

                entity.Property(e => e.WorldRegionCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Identifier of the world region where the country is located.");

                entity.Property(e => e.WorldSubregionCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Identifier of the world subregion where the country is located.");

                entity.HasOne(d => d.WorldRegionCodeNavigation)
                    .WithMany(p => p.CountryWorldRegionCodeNavigations)
                    .HasForeignKey(d => d.WorldRegionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCountry_WorldRegion");

                entity.HasOne(d => d.WorldSubregionCodeNavigation)
                    .WithMany(p => p.CountryWorldSubregionCodeNavigations)
                    .HasForeignKey(d => d.WorldSubregionCode)
                    .HasConstraintName("fkCountry_WorldSubregion");
            });

            modelBuilder.Entity<CountryDivision>(entity =>
            {
                entity.HasKey(e => new { e.CountryCode, e.CountryDivisionCode })
                    .HasName("pkcCountryDivision");

                entity.ToTable("CountryDivision", "Core");

                entity.HasComment("Lookup table representing the world regions as defined by the ISO 3166-2 standard.");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Identifier of the country the country division is associated with.");

                entity.Property(e => e.CountryDivisionCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Identifier of the country division using the ISO 3166-2 Alpha-2 code.");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("The category name of the country division.");

                entity.Property(e => e.CountryDivisionName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Name of the country using the ISO 3166-2 Subdivision Name.");

                entity.Property(e => e.RowStatusId).HasComment("Identifier of the status for the record (i.e. enabled, disabled, deleted, etc.).");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.CountryDivisions)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCountryDivision_Country");
            });

            modelBuilder.Entity<DigitalAsset>(entity =>
            {
                entity.ToTable("DigitalAsset", "DCM");

                entity.HasComment("Represents a digital asset maintained by the Digital Content Management System.");

                entity.Property(e => e.DigitalAssetId).HasComment("Identifier of the DigitalAsset record.");

                entity.Property(e => e.AltTextId).HasComment("Identifier of the Content used as the digital asset's alternate text.");

                entity.Property(e => e.CaptionId).HasComment("Identifier of the Content used as the digital asset's caption.");

                entity.Property(e => e.DigitalAssetName)
                    .HasMaxLength(100)
                    .HasComment("The name of the Digital Asset.");

                entity.Property(e => e.DigitalAssetTypeId).HasComment("Identifier of the associated Digital Asset Type.");

                entity.Property(e => e.DigitalAssetUrl)
                    .HasMaxLength(500)
                    .HasComment("The URL to the digital asset.");

                entity.Property(e => e.Discriminator)
                    .HasMaxLength(100)
                    .HasComment("Characteristic to distinguish digital assets within a group.");

                entity.Property(e => e.EffectiveEndDate)
                    .HasDefaultValueSql("('9999-12-31 23:59:59')")
                    .HasComment("The date and time the Digital Asset is no longer effective.");

                entity.Property(e => e.EffectiveStartDate)
                    .HasDefaultValueSql("(getutcdate())")
                    .HasComment("The date and time the Digital Asset becomes effective.");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(100)
                    .HasComment("The tenant's identifier for the Digital Asset.");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("Flag indicating whether the DigitalAsset is active.");

                entity.Property(e => e.ThumbnailUrl)
                    .HasMaxLength(500)
                    .HasComment("The URL to the thumbnail for the digital asset.");

                entity.HasOne(d => d.AltText)
                    .WithMany(p => p.DigitalAssetAltTexts)
                    .HasForeignKey(d => d.AltTextId)
                    .HasConstraintName("fkDigitalAsset_Content_AltText");

                entity.HasOne(d => d.Caption)
                    .WithMany(p => p.DigitalAssetCaptions)
                    .HasForeignKey(d => d.CaptionId)
                    .HasConstraintName("fkDigitalAsset_Content_Caption");

                entity.HasOne(d => d.DigitalAssetType)
                    .WithMany(p => p.DigitalAssets)
                    .HasForeignKey(d => d.DigitalAssetTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkDigitalAsset_DigitalAssetType");
            });

            modelBuilder.Entity<DigitalAssetType>(entity =>
            {
                entity.ToTable("DigitalAssetType", "DCM");

                entity.HasComment("Defines the types of digital asset locations supported by the system.");

                entity.Property(e => e.DigitalAssetTypeId)
                    .ValueGeneratedNever()
                    .HasComment("Identifier of the Digital Asset Type record.");

                entity.Property(e => e.DigitalAssetTypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("The name of the Digital Asset Type.");

                entity.Property(e => e.Discriminator)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("The discriminator used when saving the different digital asset types.");

                entity.Property(e => e.RowStatusId).HasComment("Identifier of the record status (i.e. enabled, disabled, deleted, etc.).");

                entity.Property(e => e.SortOrder).HasComment("Sorting order of the Digital Asset Type.");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.LanguageCode)
                    .HasName("pkcLanguage");

                entity.ToTable("Language", "Core");

                entity.HasComment("Represents a spoken/written language.");

                entity.Property(e => e.LanguageCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Identifier of the language.");

                entity.Property(e => e.LanguageName)
                    .HasMaxLength(100)
                    .HasComment("Name of the language.");

                entity.Property(e => e.NativeName)
                    .HasMaxLength(100)
                    .HasComment("Native name of the language.");

                entity.Property(e => e.RowStatusId).HasComment("Identifier of the status for the record (i.e. enabled, disabled, deleted, etc.).");
            });

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

            modelBuilder.Entity<PayorType>(entity =>
            {
                entity.ToTable("PayorType", "PM");

                entity.HasComment("Represents a type of payor.");

                entity.HasIndex(e => e.ExternalId, "unqPayorType_ExternalId")
                    .IsUnique()
                    .HasFilter("([ExternalId] IS NOT NULL)");

                entity.Property(e => e.PayorTypeId).HasComment("Identifier of the payor type.");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(100)
                    .HasComment("The tenant's identifier for the payor type.");

                entity.Property(e => e.PayorTypeName)
                    .HasMaxLength(100)
                    .HasComment("The name of the payor type.");

                entity.Property(e => e.RowStatusId)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Identifier of the status for the row (i.e. enabled, disabled, etc.).");

                entity.Property(e => e.SortOrder).HasComment("The sort order of the payor type within the full listing of payor types.");
            });

            modelBuilder.Entity<PhoneNumberType>(entity =>
            {
                entity.ToTable("PhoneNumberType", "PM");

                entity.HasComment("Lookup values representing phone number types used by Glennis.");

                entity.HasIndex(e => e.ExternalId, "unqPhoneNumberType_ExternalId")
                    .IsUnique()
                    .HasFilter("([ExternalId] IS NOT NULL)");

                entity.Property(e => e.PhoneNumberTypeId).HasComment("Identifier of the phone number type.");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(100)
                    .HasComment("The operator identifier for the phone number type.");

                entity.Property(e => e.IsDefault).HasComment("Flag indicating whether the phone number type is the default phone number type.");

                entity.Property(e => e.PhoneNumberTypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Name of the phone number type.");

                entity.Property(e => e.RowStatusId)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Identifier of the status for the row (i.e. enabled, disabled, etc.).");

                entity.Property(e => e.SortOrder).HasComment("The sorting order of the phone number type.");
            });

            modelBuilder.Entity<PostalAddressType>(entity =>
            {
                entity.ToTable("PostalAddressType", "PM");

                entity.HasComment("Lookup values representing phone number types used by Glennis.");

                entity.HasIndex(e => e.ExternalId, "unqPostalAddressType_ExternalId")
                    .IsUnique()
                    .HasFilter("([ExternalId] IS NOT NULL)");

                entity.Property(e => e.PostalAddressTypeId).HasComment("Identifier of the phone number type.");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(100)
                    .HasComment("The operator identifier for the phone number type.");

                entity.Property(e => e.IsDefault).HasComment("Flag indicating whether the phone number type is the default phone number type.");

                entity.Property(e => e.PostalAddressTypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Name of the phone number type.");

                entity.Property(e => e.RowStatusId)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Identifier of the status for the row (i.e. enabled, disabled, etc.).");

                entity.Property(e => e.SortOrder).HasComment("The sorting order of the phone number type.");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room", "PM");

                entity.HasComment("Represents a room within a community.")
                    .ToTable(tb => tb.IsTemporal(ttb =>
    {
        ttb.UseHistoryTable("RoomHistory", "PM");
        ttb
            .HasPeriodStart("ValidFrom")
            .HasColumnName("ValidFrom");
        ttb
            .HasPeriodEnd("ValidTo")
            .HasColumnName("ValidTo");
    }
));

                entity.HasIndex(e => e.CommunityId, "idxRoom_CommunityId");

                entity.HasIndex(e => e.ExternalId, "unqRoom_ExternalId")
                    .IsUnique()
                    .HasFilter("([ExternalId] IS NOT NULL)");

                entity.Property(e => e.RoomId).HasComment("Identifier of the room record.");

                entity.Property(e => e.CommunityId).HasComment("Identifier of the associated community record.");

                entity.Property(e => e.CommunityStructureId).HasComment("Identifier of the associated community structure element (floor, building, etc.).");

                entity.Property(e => e.ContentId).HasComment("Identifier of the associated content record.");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(100)
                    .HasComment("Identifier for the room from an external system.");

                entity.Property(e => e.FloorPlanId).HasComment("Identifier of the digital asset representing the floor plan for the room when it differs from the room type's floor plan.");

                entity.Property(e => e.IsFeatured).HasComment("Flag indicating whether the room is considered as featured.");

                entity.Property(e => e.RoomArea).HasComment("The size of the room. The measurement type is based off of Community.RoomMeasurement.");

                entity.Property(e => e.RoomAvailabilityId).HasComment("Identifier of the associated room availability record.");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(100)
                    .HasComment("The name of the room.");

                entity.Property(e => e.RoomNumber)
                    .HasMaxLength(100)
                    .HasComment("The number of the room.");

                entity.Property(e => e.RoomTypeId).HasComment("Identifier of the associated room type record.");

                entity.Property(e => e.RowStatusId).HasDefaultValueSql("((1))");

                entity.Property(e => e.SortOrder).HasComment("The sorting order of the room among the other rooms.");

                entity.HasOne(d => d.AssignedCareType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.AssignedCareTypeId)
                    .HasConstraintName("fkRoom_CareType");

                entity.HasOne(d => d.Community)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.CommunityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkRoom_Community");

                entity.HasOne(d => d.CommunityStructure)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.CommunityStructureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkRoom_CommunityStructure");

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.ContentId)
                    .HasConstraintName("fkRoom_Content");

                entity.HasOne(d => d.FloorPlan)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.FloorPlanId)
                    .HasConstraintName("fkRoom_DigitalAsset");

                entity.HasOne(d => d.RoomAvailability)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomAvailabilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkRoom_RoomAvailability");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkRoom_RoomType");
            });

            modelBuilder.Entity<RoomAvailability>(entity =>
            {
                entity.ToTable("RoomAvailability", "PM");

                entity.HasComment("Represents the communities managed by the tenant provider.");

                entity.HasIndex(e => e.ExternalId, "unqRoomAvailability_ExternalId")
                    .IsUnique()
                    .HasFilter("([ExternalId] IS NOT NULL)");

                entity.Property(e => e.RoomAvailabilityId).HasComment("Identifier of the room availability record.");

                entity.Property(e => e.BackgroundColor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(100)
                    .HasComment("The external (customer) identifier assigned to the room availability.");

                entity.Property(e => e.ForegroundColor)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RoomAvailabilityName)
                    .HasMaxLength(100)
                    .HasComment("The name of the room availability type.");

                entity.Property(e => e.RowStatusId).HasDefaultValueSql("((1))");

                entity.Property(e => e.ShowAsAvailable).HasComment("Flag indicating whether the room availability type is shown as available.");

                entity.Property(e => e.ShowAsReserved).HasComment("Flag indicating whether the room availability type is shown as reserved.");

                entity.Property(e => e.SortOrder).HasComment("The sort order of the room availability type within the full listing of room availability types.");
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

            modelBuilder.Entity<RoomRate>(entity =>
            {
                entity.ToTable("RoomRate", "PM");

                entity.HasComment("Represents the rate information for a room for a specific set of dates..")
                    .ToTable(tb => tb.IsTemporal(ttb =>
    {
        ttb.UseHistoryTable("RoomRateHistory", "PM");
        ttb
            .HasPeriodStart("ValidFrom")
            .HasColumnName("ValidFrom");
        ttb
            .HasPeriodEnd("ValidTo")
            .HasColumnName("ValidTo");
    }
));

                entity.HasIndex(e => e.RoomId, "INDEX_RoomRateID");

                entity.HasIndex(e => new { e.PayorTypeId, e.RoomId, e.EffectiveStartDate, e.EffectiveEndDate }, "ncixRoomRate_EffectiveDates");

                entity.Property(e => e.RoomRateId).HasComment("Identifier of the room rate.");

                entity.Property(e => e.AdministrativeFee)
                    .HasColumnType("smallmoney")
                    .HasComment("The standard administrative fee applied to the room.");

                entity.Property(e => e.BaseRate)
                    .HasColumnType("smallmoney")
                    .HasComment("The base (MSRP) rate for the room, room rate type, and payor type.");

                entity.Property(e => e.DailyRate)
                    .HasColumnType("smallmoney")
                    .HasComment("The daily rate for the room.");

                entity.Property(e => e.DiscountedRate)
                    .HasColumnType("smallmoney")
                    .HasComment("The discounted rate (starting at) for the room.");

                entity.Property(e => e.EffectiveEndDate)
                    .HasDefaultValueSql("('9999-12-31 23:59:59')")
                    .HasComment("The date and time the rate information is no longer effective.");

                entity.Property(e => e.EffectiveStartDate)
                    .HasDefaultValueSql("(getutcdate())")
                    .HasComment("The date and time the rate information is effective.");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(100)
                    .HasComment("The tenant's identifier for the room rate.");

                entity.Property(e => e.MaxConcession)
                    .HasColumnType("smallmoney")
                    .HasComment("The max concession allowed for the room.");

                entity.Property(e => e.MaximumRate)
                    .HasColumnType("smallmoney")
                    .HasComment("The maximum amount accepted for the room.");

                entity.Property(e => e.MinimumRate)
                    .HasColumnType("smallmoney")
                    .HasComment("The minimum amount accepted for the room.");

                entity.Property(e => e.PayorTypeId).HasComment("Identifier of the associated payor type.");

                entity.Property(e => e.RoomId).HasComment("Identifier of the associated room.");

                entity.Property(e => e.RowStatusId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.PayorType)
                    .WithMany(p => p.RoomRates)
                    .HasForeignKey(d => d.PayorTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkRoomRate_PayorType");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomRates)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkRoomRate_Room");
            });

            modelBuilder.Entity<RoomStyle>(entity =>
            {
                entity.ToTable("RoomStyle", "PM");

                entity.HasComment("Represents a room style.");

                entity.HasIndex(e => e.ExternalId, "unqRoomStyle_ExternalId")
                    .IsUnique()
                    .HasFilter("([ExternalId] IS NOT NULL)");

                entity.Property(e => e.RoomStyleId).HasComment("Identifier of the room style record.");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(100)
                    .HasComment("The tenant's external identifier for the style.");

                entity.Property(e => e.RoomStyleCode)
                    .HasMaxLength(20)
                    .HasComment("The code assigned to the room style.");

                entity.Property(e => e.RoomStyleName)
                    .HasMaxLength(100)
                    .HasComment("Name of the room style.");

                entity.Property(e => e.RowStatusId)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Identifier of the record row status (i.e. enabled, disabled, etc.).");

                entity.Property(e => e.SortOrder).HasComment("The sort order of the room style within the full listing of room styles.");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("RoomType", "PM");

                entity.HasComment("Represents a room type.");

                entity.HasIndex(e => e.ExternalId, "unqRoomType_ExternalId")
                    .IsUnique()
                    .HasFilter("([ExternalId] IS NOT NULL)");

                entity.Property(e => e.RoomTypeId).HasComment("Identifier of the room type record.");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(100)
                    .HasComment("The tenant's identifier for the room type.");

                entity.Property(e => e.RoomStyleId).HasComment("Identifier of the associated room style.");

                entity.Property(e => e.RoomTypeCategoryId).HasComment("Identifier of the category of room type.");

                entity.Property(e => e.RoomTypeCode)
                    .HasMaxLength(20)
                    .HasComment("A short code for the room type.");

                entity.Property(e => e.RoomTypeName)
                    .HasMaxLength(100)
                    .HasComment("Name of the room type.");

                entity.Property(e => e.RowStatusId)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Identifier of the room type record status (i.e. enabled, disabled, etc).");

                entity.Property(e => e.SortOrder).HasComment("The sorting order of the room type among the other room types.");

                entity.HasOne(d => d.RoomStyle)
                    .WithMany(p => p.RoomTypes)
                    .HasForeignKey(d => d.RoomStyleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkRoomType_RoomStyle");

                entity.HasOne(d => d.RoomTypeCategory)
                    .WithMany(p => p.RoomTypes)
                    .HasForeignKey(d => d.RoomTypeCategoryId)
                    .HasConstraintName("fkRoomType_RoomTypeCategory");
            });

            modelBuilder.Entity<RoomTypeCategory>(entity =>
            {
                entity.ToTable("RoomTypeCategory", "PM");

                entity.HasComment("Represents a room type category.");

                entity.HasIndex(e => e.ExternalId, "unqRoomTypeCategory_ExternalId")
                    .IsUnique()
                    .HasFilter("([ExternalId] IS NOT NULL)");

                entity.Property(e => e.RoomTypeCategoryId).HasComment("Identifier of the room type category record.");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(100)
                    .HasComment("The tenant's identifier for the room type category.");

                entity.Property(e => e.RoomTypeCategoryCode)
                    .HasMaxLength(20)
                    .HasComment("The code associated with the room type category.");

                entity.Property(e => e.RoomTypeCategoryName)
                    .HasMaxLength(100)
                    .HasComment("Name of the room type category.");

                entity.Property(e => e.RowStatusId)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Identifier of the status of the room type category record (i.e. enabled, disabled, etc).");

                entity.Property(e => e.SortOrder).HasComment("The sort order of the room type category within the full listing of room type categories.");
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

            modelBuilder.Entity<WorldRegion>(entity =>
            {
                entity.HasKey(e => e.WorldRegionCode)
                    .HasName("pkcWorldRegion");

                entity.ToTable("WorldRegion", "Core");

                entity.HasComment("Lookup table representing the world regions as defined by the UN M49 specification.");

                entity.HasIndex(e => e.ParentId, "idxWorldRegion_ParentId");

                entity.Property(e => e.WorldRegionCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Identifier of the world region.");

                entity.Property(e => e.ParentId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Identifier of the world region parent (for subregions).");

                entity.Property(e => e.RowStatusId).HasComment("Identifier of the status for the record (i.e. enabled, disabled, deleted, etc.).");

                entity.Property(e => e.WorldRegionName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Name of the world region.");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("fkWorldRegion_WorldRegion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
