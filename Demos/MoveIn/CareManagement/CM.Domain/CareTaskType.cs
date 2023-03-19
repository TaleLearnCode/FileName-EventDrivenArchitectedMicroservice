namespace SLS.CM.Domain;

public partial class CareTaskType
{
	public CareTaskType()
	{
		CareTasks = new HashSet<CareTask>();
	}

	public int CareTaskTypeId { get; set; }
	public string CareTaskTypeName { get; set; } = null!;
	public int EmployeeRoleId { get; set; }
	public bool AssignToNewResidents { get; set; }
	public int RowStatusId { get; set; }

	public virtual ICollection<CareTask> CareTasks { get; set; }
}