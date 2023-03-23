namespace SLS.LM.Data;

public class LMContext : DbContext
{

  private readonly string _connectionString = string.Empty;

  public LMContext() { }

  public LMContext(string connectionString) => _connectionString = connectionString;

  public LMContext(DbContextOptions<LMContext> options) : base(options) { }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder
      .UseSqlServer(_connectionString);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    CreateModel.Community(modelBuilder);
    CreateModel.Lease(modelBuilder);
    CreateModel.LeaseTermType(modelBuilder);
    CreateModel.LeaseType(modelBuilder);
    CreateModel.Lessee(modelBuilder);
    CreateModel.Prefix(modelBuilder);
    CreateModel.Resident(modelBuilder);
    CreateModel.ResponsibleParty(modelBuilder);
    CreateModel.RowStatus(modelBuilder);
    CreateModel.Suffix(modelBuilder);
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

}