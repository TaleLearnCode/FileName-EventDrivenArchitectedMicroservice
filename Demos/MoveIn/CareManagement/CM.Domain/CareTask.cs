namespace SLS.CM.Domain;

public partial class CareTask
{
	public int CareTaskId { get; set; }
	public int CareTaskTypeId { get; set; }
	public int CareTaskStatusId { get; set; }
	public int PrimaryEmployeeId { get; set; }
	public DateTime AssignedDateTime { get; set; }
	public DateTime ExpectedStartDateTime { get; set; }
	public DateTime ExpectetdEndDateTime { get; set; }
	public DateTime? ActualStartDateTime { get; set; }
	public DateTime? ActualEndDateTime { get; set; }
}
