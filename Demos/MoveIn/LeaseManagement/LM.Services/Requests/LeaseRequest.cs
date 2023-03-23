namespace SLS.LM.Services.Requests;

public class LeaseRequest
{
  public int LeaseTypeId { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public decimal Rate { get; set; }
}