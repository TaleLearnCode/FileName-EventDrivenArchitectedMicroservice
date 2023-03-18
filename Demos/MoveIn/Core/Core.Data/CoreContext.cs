namespace SLS.Core.Data;

public class CoreContext : DbContext
{

	private readonly string _connectionString = string.Empty;

	public CoreContext() { }

	public CoreContext(string connectionString) => _connectionString = connectionString;

	public CoreContext(DbContextOptions<CoreContext> options) : base(options) { }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder
			.UseSqlServer(_connectionString);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		CreateModel.Country(modelBuilder);
		CreateModel.CountryDivision(modelBuilder);
		CreateModel.Language(modelBuilder);
		CreateModel.LanguageCulture(modelBuilder);
		CreateModel.Prefix(modelBuilder);
		CreateModel.RowStatus(modelBuilder);
		CreateModel.Suffix(modelBuilder);
		CreateModel.WorldRegion(modelBuilder);
	}

	public virtual DbSet<Country> Countries { get; set; } = null!;
	public virtual DbSet<CountryDivision> CountryDivisions { get; set; } = null!;
	public virtual DbSet<Language> Languages { get; set; } = null!;
	public virtual DbSet<LanguageCulture> LanguageCultures { get; set; } = null!;
	public virtual DbSet<Prefix> Prefixes { get; set; } = null!;
	public virtual DbSet<RowStatus> RowStatuses { get; set; } = null!;
	public virtual DbSet<Suffix> Suffixes { get; set; } = null!;
	public virtual DbSet<WorldRegion> WorldRegions { get; set; } = null!;

}