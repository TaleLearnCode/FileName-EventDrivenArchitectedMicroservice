namespace SLS.LM.Domain;

public partial class Lease
{
  public int LeaseId { get; set; }
  public string? ExternalId { get; set; }
  public int ResidentId { get; set; }
  public int LeaseTypeId { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public decimal Rate { get; set; }

  public virtual LeaseType LeaseType { get; set; } = null!;
  public virtual Resident Resident { get; set; } = null!;
}