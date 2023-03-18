namespace SLS.CM.Domain;

public partial class CareTaskType
{
	public int CareTaskTypeId { get; set; }
	public string CareTaskTypeName { get; set; } = null!;
	public int EmployeeRoleId { get; set; }
	public bool AssignToNewResidents { get; set; }
	public int RowStatusId { get; set; }
}