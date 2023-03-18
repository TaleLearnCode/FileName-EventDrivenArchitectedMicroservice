namespace SLS.CM.Domain;

public partial class EmployeeRole
{
	public int EmployeeRoleId { get; set; }
	public string EmployeeRoleName { get; set; } = null!;
	public string? EmployeeRoleCode { get; set; }
	public int RowStatusId { get; set; }
}