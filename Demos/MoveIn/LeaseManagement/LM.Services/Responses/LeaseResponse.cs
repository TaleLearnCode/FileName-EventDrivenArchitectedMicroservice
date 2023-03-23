namespace SLS.LM.Services.Responses;

public class LeaseResponse
{
  public int LeaseId { get; set; }
  public int LeaseTypeId { get; set; }
  public string? LeaseType { get; set; }
  public string? LeaseTerm { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public decimal Rate { get; set; }
  public ContactResponse Resident { get; set; } = null!;
  public ContactResponse Lessee { get; set; } = null!;
  public ContactResponse ResponsibleParty { get; set; } = null!;
}