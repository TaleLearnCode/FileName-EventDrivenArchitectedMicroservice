using Microsoft.EntityFrameworkCore;
using SLS.RM.Domain;

namespace SLS.RM.Data;

public class RMContext : DbContext
{

	private readonly string _connectionString = string.Empty;

	public RMContext() { }

	public RMContext(string connectionString) => _connectionString = connectionString;

	public RMContext(DbContextOptions<RMContext> options) : base(options) { }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder
			.UseSqlServer(_connectionString);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		CreateModel.AncillaryCare(modelBuilder);
		CreateModel.AncillaryCareCategory(modelBuilder);
		CreateModel.CareLevel(modelBuilder);
		CreateModel.CareType(modelBuilder);
		CreateModel.Community(modelBuilder);
		CreateModel.CommunityStatus(modelBuilder);
		CreateModel.Country(modelBuilder);
		CreateModel.CountryDivision(modelBuilder);
		CreateModel.Lease(modelBuilder);
		CreateModel.PayorType(modelBuilder);
		CreateModel.Prefix(modelBuilder);
		CreateModel.Relation(modelBuilder);
		CreateModel.Resident(modelBuilder);
		CreateModel.ResidentAncillaryCare(modelBuilder);
		CreateModel.ResidentCareLevel(modelBuilder);
		CreateModel.ResidentCommunity(modelBuilder);
		CreateModel.ResidentContact(modelBuilder);
		CreateModel.ResidentContactPhoneNumber(modelBuilder);
		CreateModel.ResidentContactPostalAddress(modelBuilder);
		CreateModel.ResidentContactType(modelBuilder);
		CreateModel.ResidentContactTypeRole(modelBuilder);
		CreateModel.ResidentPhoneNumberType(modelBuilder);
		CreateModel.ResidentPostalAddressType(modelBuilder);
		CreateModel.ResidentRoom(modelBuilder);
		CreateModel.Room(modelBuilder);
		CreateModel.RowStatus(modelBuilder);
		CreateModel.Suffix(modelBuilder);
	}

	public virtual DbSet<AncillaryCare> AncillaryCares { get; set; } = null!;
	public virtual DbSet<AncillaryCareCategory> AncillaryCareCategories { get; set; } = null!;
	public virtual DbSet<CareLevel> CareLevels { get; set; } = null!;
	public virtual DbSet<CareType> CareTypes { get; set; } = null!;
	public virtual DbSet<Community> Communities { get; set; } = null!;
	public virtual DbSet<CommunityStatus> CommunityStatuses { get; set; } = null!;
	public virtual DbSet<Country> Countries { get; set; } = null!;
	public virtual DbSet<CountryDivision> CountryDivisions { get; set; } = null!;
	public virtual DbSet<Lease> Leases { get; set; } = null!;
	public virtual DbSet<PayorType> PayorTypes { get; set; } = null!;
	public virtual DbSet<Prefix> Prefixes { get; set; } = null!;
	public virtual DbSet<Relation> Relations { get; set; } = null!;
	public virtual DbSet<Resident> Residents { get; set; } = null!;
	public virtual DbSet<ResidentAncillaryCare> ResidentAncillaryCares { get; set; } = null!;
	public virtual DbSet<ResidentCareLevel> ResidentCareLevels { get; set; } = null!;
	public virtual DbSet<ResidentCommunity> ResidentCommunities { get; set; } = null!;
	public virtual DbSet<ResidentContact> ResidentContacts { get; set; } = null!;
	public virtual DbSet<ResidentContactPhoneNumber> ResidentContactPhoneNumbers { get; set; } = null!;
	public virtual DbSet<ResidentContactPostalAddress> ResidentContactPostalAddresses { get; set; } = null!;
	public virtual DbSet<ResidentContactType> ResidentContactTypes { get; set; } = null!;
	public virtual DbSet<ResidentContactTypeRole> ResidentContactTypeRoles { get; set; } = null!;
	public virtual DbSet<ResidentPhoneNumberType> ResidentPhoneNumberTypes { get; set; } = null!;
	public virtual DbSet<ResidentPostalAddressType> ResidentPostalAddressTypes { get; set; } = null!;
	public virtual DbSet<ResidentRoom> ResidentRooms { get; set; } = null!;
	public virtual DbSet<ResidentRoomHistory> ResidentRoomHistories { get; set; } = null!;
	public virtual DbSet<Room> Rooms { get; set; } = null!;
	public virtual DbSet<RowStatus> RowStatuses { get; set; } = null!;
	public virtual DbSet<Suffix> Suffixes { get; set; } = null!;

}