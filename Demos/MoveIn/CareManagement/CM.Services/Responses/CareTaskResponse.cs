namespace SLS.CM.Services.Responses;

public class CareTaskResponse
{
	public int CareTaskId { get; set; }
	public string? TaskType { get; set; }
	public string? Status { get; set; }
	public DateTime? AssignedDateTime { get; set; }
}