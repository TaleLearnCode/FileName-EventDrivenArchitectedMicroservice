namespace SLS.CM.Data;

public class CMContext : DbContext
{

	private readonly string _connectionString = string.Empty;

	public CMContext() { }

	public CMContext(string connectionString) => _connectionString = connectionString;

	public CMContext(DbContextOptions<CMContext> options) : base(options) { }

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
		CreateModel.CareTask(modelBuilder);
		CreateModel.CareTaskResident(modelBuilder);
		CreateModel.CareTaskStatus(modelBuilder);
		CreateModel.CareTaskType(modelBuilder);
		CreateModel.CareType(modelBuilder);
		CreateModel.Community(modelBuilder);
		CreateModel.CommunityStatus(modelBuilder);
		CreateModel.Employee(modelBuilder);
		CreateModel.EmployeeRole(modelBuilder);
		CreateModel.Resident(modelBuilder);
		CreateModel.ResidentAncillaryCare(modelBuilder);
		CreateModel.ResidentCommunity(modelBuilder);
		CreateModel.ResidentRoom(modelBuilder);
		CreateModel.Room(modelBuilder);
		CreateModel.RoomCareType(modelBuilder);
		CreateModel.RowStatus(modelBuilder);
	}

	public virtual DbSet<AncillaryCare> AncillaryCares { get; set; } = null!;
	public virtual DbSet<AncillaryCareCategory> AncillaryCareCategories { get; set; } = null!;
	public virtual DbSet<CareTask> CareTasks { get; set; } = null!;
	public virtual DbSet<CareTaskResident> CareTaskResidents { get; set; } = null!;
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

}