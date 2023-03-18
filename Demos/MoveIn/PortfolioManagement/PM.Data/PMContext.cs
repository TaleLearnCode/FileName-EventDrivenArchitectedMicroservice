namespace SLS.PM.Data;

public class PMContext : DbContext
{

	private readonly string _connectionString = string.Empty;

	public PMContext() { }

	public PMContext(string connectionString) => _connectionString = connectionString;

	public PMContext(DbContextOptions<PMContext> options) : base(options) { }

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
		CreateModel.CommunityAncillaryCare(modelBuilder);
		CreateModel.CommunityCareLevel(modelBuilder);
		CreateModel.CommunityPhoneNumber(modelBuilder);
		CreateModel.CommunityPostalAddress(modelBuilder);
		CreateModel.CommunityRoomType(modelBuilder);
		CreateModel.CommunityStatus(modelBuilder);
		CreateModel.CommunityStructure(modelBuilder);
		CreateModel.CommunityStructureType(modelBuilder);
		CreateModel.Content(modelBuilder);
		CreateModel.ContentCopy(modelBuilder);
		CreateModel.Country(modelBuilder);
		CreateModel.CountryDivision(modelBuilder);
		CreateModel.DigitalAsset(modelBuilder);
		CreateModel.Language(modelBuilder);
		CreateModel.LanguageCulture(modelBuilder);
		CreateModel.PayorType(modelBuilder);
		CreateModel.PhoneNumberType(modelBuilder);
		CreateModel.PostalAddressType(modelBuilder);
		CreateModel.Room(modelBuilder);
		CreateModel.RoomAvailability(modelBuilder);
		CreateModel.RoomCareType(modelBuilder);
		CreateModel.RoomRate(modelBuilder);
		CreateModel.RoomStyle(modelBuilder);
		CreateModel.RoomType(modelBuilder);
		CreateModel.RoomTypeCategory(modelBuilder);
		CreateModel.RowStatus(modelBuilder);
		CreateModel.WorldRegion(modelBuilder);
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


}